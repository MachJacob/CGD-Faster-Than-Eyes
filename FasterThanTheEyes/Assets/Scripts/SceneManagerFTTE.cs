using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SceneManagerFTTE : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string MusicEvent;
    FMOD.Studio.EventInstance Music;
    private bool gameOver = false;
    [SerializeField]
    private Canvas mainMenuCanvas;
    [SerializeField]
    private Canvas gameOverCanvas;
    [SerializeField]
    private Canvas inGameUI;
    [SerializeField]
    private Fade fade;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    public static bool fmodEnable;
    [SerializeField]
    private FogTrigger[] fogtriggers;

    public int numEnemiesKilled = 0;

    private float menu = 2.0f;
    private float stage1 = 2.0f;
    private float stage2 = 3.0f;
    private float stage3 = 4.0f;
    private float bossStage = 5.0f;
    private float game_Over = 6.0f;
    private bool loadComplete = false;
    private bool inGame = false;

    private void Awake()
    {
        mainMenuCanvas.gameObject.SetActive(true);
        gameOverCanvas.gameObject.SetActive(false);
        inGameUI.enabled = false;
        fmodEnable = false;

        if (MusicEvent != "")
        {
            Music = FMODUnity.RuntimeManager.CreateInstance(MusicEvent);
            Music.setParameterByName("PlayerHealth", player.GetComponent<PlayerHealth>().health);
            Music.setParameterByName("Stage", menu);
            Music.setParameterByName("NumberEnemies", 0.0f);
            Music.setParameterByName("MistAmount", 0.0f);
            Music.start();
            fmodEnable = true;
        }

    }
    public void StartFade()
    {
        mainMenuCanvas.gameObject.SetActive(false);
        fade.setFade(1);
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

    
    void Update()
    {
        if(fade.loadScene && !loadComplete)
        {
            fade.loadScene = false;
            LoadGame();
        }
        if(gameOver)
        {
            inGame = false;
            Music.setParameterByName("Stage", game_Over);
            inGameUI.gameObject.SetActive(false);
            gameOverCanvas.gameObject.SetActive(true);
        }
        if(inGame)
        {
            
            Music.setParameterByName("PlayerHealth", player.GetComponent<PlayerHealth>().health);
            Music.setParameterByName("Stage", menu);
            CheckFogTriggers();
           // need way of knowing how many enemies currently spawned and how much mist is in the level
            // Music.setParameterByName("NumberEnemies", 0.0f);
           // Music.setParameterByName("MistAmount", 0.0f);
        }

    }
   private void LoadGame()
    {
        GetComponent<CameraSwitcher>().SwitchCams(true, false);
        inGameUI.gameObject.SetActive(true);
        fade.setFade(0);
        loadComplete = true;
        PlayerScore.playing = true;
        Music.setParameterByName("Stage", menu);
        inGame = true;
    }
    private void CheckFogTriggers()
    {
        if(fogtriggers[3].triggered && fogtriggers[3].mySpawner.numSpawned == fogtriggers[3].mySpawner.NumToSpawn)
        {
            if (numEnemiesKilled == fogtriggers[0].mySpawner.NumToSpawn + fogtriggers[1].mySpawner.NumToSpawn + fogtriggers[2].mySpawner.NumToSpawn + fogtriggers[3].mySpawner.NumToSpawn)
            {
                if (!fogtriggers[3].finished)
                {
                    fogtriggers[3].Finished();
                }
            }
        }
        else if (fogtriggers[2].triggered && fogtriggers[2].mySpawner.numSpawned == fogtriggers[2].mySpawner.NumToSpawn)
        {
            if (numEnemiesKilled == fogtriggers[0].mySpawner.NumToSpawn + fogtriggers[1].mySpawner.NumToSpawn + fogtriggers[2].mySpawner.NumToSpawn)
            {
                if (!fogtriggers[2].finished)
                {
                    fogtriggers[2].Finished();
                }
            }
        }
        else if (fogtriggers[1].triggered && fogtriggers[1].mySpawner.numSpawned == fogtriggers[1].mySpawner.NumToSpawn)
        {
            if (numEnemiesKilled == fogtriggers[0].mySpawner.NumToSpawn + fogtriggers[1].mySpawner.NumToSpawn)
            {
                if (!fogtriggers[1].finished)
                {
                    fogtriggers[1].Finished();
                }
            }
        }
        else if (fogtriggers[0].triggered && fogtriggers[0].mySpawner.numSpawned == fogtriggers[0].mySpawner.NumToSpawn)
        {
            if(numEnemiesKilled == fogtriggers[0].mySpawner.NumToSpawn)
            {
                if (!fogtriggers[0].finished)
                {
                    fogtriggers[0].Finished();
                }
            }
        }
    }
}
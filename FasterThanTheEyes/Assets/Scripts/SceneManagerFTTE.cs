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

    private float menu = 1.0f;
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
        Music.setParameterByName("Stage", stage1);
        inGame = true;
    }

}
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerFTTE : MonoBehaviour
{
    private bool gameOver = false;
    [SerializeField]
    private Canvas mainMenuCanvas;
    [SerializeField]
    private Canvas gameOverCanvas;
    [SerializeField]
    private Canvas inGameUI;
    [SerializeField]
    private Fade fade;

    private bool loadComplete = false;
    // Start is called before the first frame update
    private void Awake()
    {
        mainMenuCanvas.gameObject.SetActive(true);
        gameOverCanvas.gameObject.SetActive(false);
        inGameUI.enabled = false;
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

            inGameUI.gameObject.SetActive(false);
            gameOverCanvas.gameObject.SetActive(true);
        }

    }
   private void LoadGame()
    {
        GetComponent<CameraSwitcher>().SwitchCams(true);
        inGameUI.gameObject.SetActive(true);
        fade.setFade(0);
        loadComplete = true;
        PlayerScore.playing = true;
    }

}
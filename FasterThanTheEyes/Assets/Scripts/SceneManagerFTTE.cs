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
    // Start is called before the first frame update
    private void Awake()
    {
        mainMenuCanvas.enabled = true;
        gameOverCanvas.enabled = false;
        inGameUI.enabled = false;
    }
    public void StartFade()
    {
        mainMenuCanvas.enabled = false;
        fade.setFade(1);
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

    
    void Update()
    {
        if(fade.loadScene)
        {
            LoadGame();
        }
        if(gameOver)
        {

            gameOverCanvas.enabled = true;
            inGameUI.enabled = false;
        }

    }
   private void LoadGame()
    {
        GetComponent<CameraSwitcher>().SwitchCams(true);
        inGameUI.enabled = true;
        mainMenuCanvas.enabled = false;
        fade.setFade(0);
    }

}
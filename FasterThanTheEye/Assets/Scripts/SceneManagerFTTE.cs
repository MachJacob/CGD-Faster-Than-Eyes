using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerFTTE : MonoBehaviour
{
    private bool gameOver = false;
    [SerializeField]
    private GameObject mainMenuCanvas;
    [SerializeField]
    private GameObject gameOverCanvas;
    [SerializeField]
    private GameObject inGameUI;
    [SerializeField]
    private Fade fade;
    // Start is called before the first frame update
    private void Awake()
    {
        mainMenuCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        inGameUI.SetActive(false);
    }
    public void StartFade()
    {
        mainMenuCanvas.SetActive(false);
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

            inGameUI.SetActive(false);
            gameOverCanvas.SetActive(true);
        }

    }
   private void LoadGame()
    {
        inGameUI.SetActive(true);
        mainMenuCanvas.SetActive(false);
        fade.setFade(0);
    }

}
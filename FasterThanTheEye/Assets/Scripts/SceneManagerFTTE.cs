using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerFTTE : MonoBehaviour
{
    public static SceneManagerFTTE instance;
    private bool gameOver;
    private bool onePlayer = false;
    private string scene = "GameScene";
    Fade fade;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            fade = FindObjectOfType<Fade>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void LoadScene(bool onePlayer)
    {
        this.onePlayer = onePlayer;
        if (SceneManager.GetActiveScene().name == scene)
            return;
        fade.setFade(1);
    }
    public void ExitGame()
    {
       // UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
        Debug.Log("Game is exiting");
    }

    
    void Update()
    {
        if(fade.loadScene)
        { 
            SceneManager.LoadScene(scene);
        }
        string activeScene = SceneManager.GetActiveScene().name;

        if (activeScene!= scene)
        {
            activeScene = SceneManager.GetActiveScene().name;
        }
        else if(activeScene == scene && fade.loadScene)
        {

            fade.loadScene = false;
            fade.setFade(0);
        }
        if(gameOver)
        {
            SceneManager.LoadScene("GameOver");
            activeScene = SceneManager.GetActiveScene().name;
            if (activeScene != "GameOver")
            {
                activeScene = SceneManager.GetActiveScene().name;
            }
            else if (activeScene == "GameOver")
            {

            }
        }

    }
    public bool GetOnePlayer()
    {
        return onePlayer;
    }

}
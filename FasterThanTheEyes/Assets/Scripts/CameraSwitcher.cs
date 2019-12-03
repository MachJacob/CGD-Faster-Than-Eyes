using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField]
    private Camera mainMenuCam;
    [SerializeField]
    private Camera playerCam;
    [SerializeField]
    private Camera transitionCam;
    // Start is called before the first frame update
    void Awake()
    {
        mainMenuCam.enabled = true;
        playerCam.enabled = false;
        transitionCam.enabled = false;
    }

    public void SwitchCams(bool playerCamera, bool transitionCamera)
    {
        if(playerCamera)
        {
            mainMenuCam.enabled = false;
            playerCam.enabled = true;
            transitionCam.enabled = false;
        }
        else if(transitionCamera && !playerCamera)
        {
            mainMenuCam.enabled = false;
            playerCam.enabled = false;
            transitionCam.enabled = true;
        }
        else
        {
            mainMenuCam.enabled = true;
            playerCam.enabled = false;
            transitionCam.enabled = false;
        }
    }
}

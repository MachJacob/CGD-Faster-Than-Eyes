using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField]
    private Camera mainMenuCam;
    [SerializeField]
    private Camera playerCam;
    // Start is called before the first frame update
    void Awake()
    {
        mainMenuCam.enabled = true;
        playerCam.enabled = false;
    }

    public void SwitchCams(bool playerCamera)
    {
        if(playerCamera)
        {
            mainMenuCam.enabled = false;
            playerCam.enabled = true;
        }
        else
        {
            mainMenuCam.enabled = true;
            playerCam.enabled = false;
        }
    }
}

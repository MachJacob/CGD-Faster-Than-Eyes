using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStart : MonoBehaviour
{
    public Camera cam;
    bool zoomCam = false;
    public GameObject MenuStuff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        zoomCam = true;
        MenuStuff.SetActive(false);

        //cam.orthographicSize -= 15f;
    }
    // Update is called once per frame
    void Update()
    {
        if (zoomCam && cam.orthographicSize > 10)
        {
            cam.orthographicSize -= 20f * Time.deltaTime;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{

    public Transform target;

    float speed = 6.0f;

    public bool transition = false;
    private float timer = 2.0f;
    private float counter = 0.0f;

    void Awake()
    {
        transition = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!transition)
        {
            while (counter < timer)
            {
                counter -= Time.deltaTime;
                var step = speed * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, target.localRotation, step);
            }
        }

        if(transition)
        {
            while (counter < timer)
            {
                counter -= Time.deltaTime;
                var step = speed * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, target.localRotation, step);
            }
        }
    }

    


}

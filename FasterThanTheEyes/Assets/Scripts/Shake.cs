using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public int counter = 0;
    private int timeShake = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counter < timeShake)
        {
            counter++;
            this.transform.Rotate(1 * Time.deltaTime, 0, 1 * Time.deltaTime);
        }

        else if (counter < timeShake * 2)
        {
            counter++;
            this.transform.Rotate(-1 * Time.deltaTime, 0, -1 * Time.deltaTime);
        }

        else
        {
            counter = 0;
        }

    }
}

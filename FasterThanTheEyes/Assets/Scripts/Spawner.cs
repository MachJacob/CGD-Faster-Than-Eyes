using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ObjectToSpawn;

    public GameObject spawnLocale1;
    public GameObject spawnLocale2;
    public GameObject spawnLocale3;
    public GameObject spawnLocale4;

    protected Transform myTransform;
    public float SecondsToWait = 25;
    public float counter = 0;
    public int Random_Number;
    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counter < SecondsToWait)
        {
            counter += 1;
        }

        else
        {
            Random_Number = Random.Range(1, 8);
            counter = 0;
            Vector3 getPos = transform.position;

            if(Random_Number == 1)
            {
                Instantiate(ObjectToSpawn, spawnLocale1.transform.position, spawnLocale1.transform.rotation);
            }

            if (Random_Number == 2)
            {
                Instantiate(ObjectToSpawn, spawnLocale2.transform.position, spawnLocale1.transform.rotation);
            }

            if (Random_Number == 3)
            {
                Instantiate(ObjectToSpawn, spawnLocale3.transform.position, spawnLocale1.transform.rotation);
            }

            if (Random_Number == 4)
            {
                Instantiate(ObjectToSpawn, spawnLocale4.transform.position, spawnLocale1.transform.rotation);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public GameObject ObjectToSpawn2;
    public GameObject spawnLocale1;
    public GameObject spawnLocale2;
    public GameObject spawnLocale3;
    public GameObject spawnLocale4;

    protected Transform myTransform;
    public float SecondsToWait = 25;
    public float counter = 0;
    public int Random_Number;
    private int numSpawned;
    public int NumToSpawn = 5;    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counter < SecondsToWait)
        {
            counter += Time.deltaTime;
        }

        else
        {
            Random_Number = Random.Range(1, 4);
            counter = 25.0f;
            Vector3 getPos = transform.position;

            if(Random_Number == 1)
            {
                Instantiate(Random.Range(0,1) == 1? ObjectToSpawn : ObjectToSpawn2, spawnLocale1.transform.position, spawnLocale1.transform.rotation);
                numSpawned++;
            }

            if (Random_Number == 2)
            {
                Instantiate(Random.Range(0, 1) == 1 ? ObjectToSpawn : ObjectToSpawn2, spawnLocale2.transform.position, spawnLocale2.transform.rotation);
                numSpawned++;
            }

            if (Random_Number == 3)
            {
                Instantiate(Random.Range(0, 1) == 1 ? ObjectToSpawn : ObjectToSpawn2, spawnLocale3.transform.position, spawnLocale3.transform.rotation);
                numSpawned++;
            }

            if (Random_Number == 4)
            {
                Instantiate(Random.Range(0, 1) == 1 ? ObjectToSpawn : ObjectToSpawn2, spawnLocale4.transform.position, spawnLocale4.transform.rotation);
                numSpawned++;
            }
        }
    }
}

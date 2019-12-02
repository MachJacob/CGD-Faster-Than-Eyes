using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public GameObject ObjectToSpawn2;
    [SerializeField]
    public GameObject[] spawnLocale;

    protected Transform myTransform;
    public float SecondsToWait = 25;
    public float counter = 0;
    public int Random_Number;
    private int numSpawned;
    [SerializeField]
    public int NumToSpawn;    // Start is called before the first frame update
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
            Random_Number = Random.Range(0, spawnLocale.Length);
            counter = 25.0f;
            Vector3 getPos = transform.position;

            Instantiate(Random.Range(0, 1) == 1 ? ObjectToSpawn : ObjectToSpawn2, spawnLocale[Random_Number].transform.position, spawnLocale[Random_Number].transform.rotation);
            numSpawned++;
        }
    }
}

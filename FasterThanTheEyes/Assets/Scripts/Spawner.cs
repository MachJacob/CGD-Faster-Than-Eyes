using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public GameObject[] ObjectToSpawn;
    [SerializeField]
    public Transform[] spawnLocale;
    [SerializeField]
    public GameObject player;

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
        else if(numSpawned < NumToSpawn)
        {
            Random_Number = Random.Range(0, spawnLocale.Length -1);
            counter = 0.0f;
            Vector3 getPos = transform.position;
            int EnemyType = numSpawned % 2;
            GameObject Enemy = Instantiate(ObjectToSpawn[EnemyType], spawnLocale[Random_Number].position, spawnLocale[Random_Number].rotation);
            if (EnemyType == 0)
            {
                Enemy.GetComponent<EnemyMovement>().Player = player;
            }
            if (EnemyType == 1)
            {
                Enemy.GetComponent<EnemyCaster>().Player = player;
            }
            numSpawned++;
        }
    }
}

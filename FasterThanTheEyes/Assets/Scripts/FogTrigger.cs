using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FogTrigger : MonoBehaviour
{
    private bool triggered = false;
    [SerializeField]
    private float minSize;
    [SerializeField]
    private float time;
    private Spawner mySpawner;
    private Collider fogCollider;
    [SerializeField]
    private GameObject[] fightBlockers;
    private void Awake()
    {
        mySpawner = GetComponent<Spawner>();
        mySpawner.enabled = false;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (!triggered)
        {
            triggered = true;
            mySpawner.enabled = true;
            if (other.gameObject.tag == "FogDestroyer")
            {
                fogCollider = other;
                fogCollider.GetComponent<CapsuleCollider>().radius = 10.0f;
            }
            foreach(GameObject fightBlocker in fightBlockers)
            {
                fightBlocker.SetActive(true);
            }
        }
    }
    private void Update()
    {
        if(triggered)
        {

            Mathf.MoveTowards(fogCollider.GetComponent<CapsuleCollider>().radius, minSize, time / Time.deltaTime);
        }
    }
}

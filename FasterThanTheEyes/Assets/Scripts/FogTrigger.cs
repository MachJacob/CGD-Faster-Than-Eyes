using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FogTrigger : MonoBehaviour
{
    public bool stageover = false;
    public bool finished = false;
    public bool triggered = false;
    [SerializeField]
    private float fogRadius;
    [SerializeField]
    private float originalfogRadius;
    [SerializeField]
    private float time;
    public Spawner mySpawner;
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
                originalfogRadius = fogCollider.GetComponent<CapsuleCollider>().radius;
            }
            foreach(GameObject fightBlocker in fightBlockers)
            {
                fightBlocker.SetActive(true);
            }
        }
    }
    private void Update()
    {
        if(!stageover)
        {
            if (triggered)
            {

                fogCollider.GetComponent<CapsuleCollider>().radius = Mathf.MoveTowards(fogCollider.GetComponent<CapsuleCollider>().radius, fogRadius, time / Time.deltaTime);
            }
            if (finished)
            {
                fogCollider.GetComponent<CapsuleCollider>().radius = Mathf.MoveTowards(fogCollider.GetComponent<CapsuleCollider>().radius, originalfogRadius, time / Time.deltaTime);
                if (fogCollider.GetComponent<CapsuleCollider>().radius == originalfogRadius)
                {
                    stageover = true;
                }
            }
        }
    }
    public void Finished()
    {
        finished = true;

        foreach (GameObject fightBlocker in fightBlockers)
        {
            fightBlocker.SetActive(false);
        }
    }
}

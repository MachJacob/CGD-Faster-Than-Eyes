using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FogTrigger : MonoBehaviour
{
    private bool triggered = false;

    private Spawner mySpawner;
    private void Awake()
    {
        mySpawner = GetComponent<Spawner>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (!triggered)
        {
            triggered = true;
            if (other.gameObject.tag == "FogDestroyer")
            {
                other.GetComponent<CapsuleCollider>().radius = 0.2f;
            }

        }
    }

}

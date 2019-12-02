using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FogTrigger : MonoBehaviour
{
    private bool triggered = false;

    private void Awake()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (!triggered)
        {

            if (other.gameObject.tag == "FogDestroyer")
            {
                other.GetComponent<CapsuleCollider>().radius = 0.2f;
            }
        }
    }

}

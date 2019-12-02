using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FogTrigger : MonoBehaviour
{
    [SerializeField]
    ParticleSystem ps;
    [SerializeField]
    ParticleSystem ps2;

    private float shorten_radius = 0.1f;
    private float normal_radius = 0.3f;

    // these lists are used to contain the particles which match
    // the trigger conditions each frame.
    List<ParticleSystem.Particle> inSide = new List<ParticleSystem.Particle>();
    // the trigger conditions each frame.
    List<ParticleSystem.Particle> inSide2 = new List<ParticleSystem.Particle>();

    private void Awake()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "FogDestroyer")
        {
            //other.GetComponent<CapsuleCollider>().radius = 0.2f;
        }
    }

}

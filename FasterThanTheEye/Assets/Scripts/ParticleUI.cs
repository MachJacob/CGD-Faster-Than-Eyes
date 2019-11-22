using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleUI : MonoBehaviour
{
    //particle systems to invoke
    public ParticleSystem system;
    private ParticleSystem systemInstance;

    public void SetParticles()
    {
        systemInstance = Instantiate(system, this.gameObject.transform.position, system.transform.rotation, this.gameObject.transform);
    }
    public void RemoveParticles()
    {
        Destroy(systemInstance.gameObject);
    }
}

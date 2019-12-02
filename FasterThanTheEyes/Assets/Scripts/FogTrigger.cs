using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FogTrigger : MonoBehaviour
{
    ParticleSystem ps;

    private float shorten_radius =- 0.1f;

    // these lists are used to contain the particles which match
    // the trigger conditions each frame.
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();
    List<ParticleSystem.Particle> inside = new List<ParticleSystem.Particle>();

    //void OnEnable()
    //{
    //    ps = GetComponent<ParticleSystem>();
    //}

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }



    void OnParticleTrigger()
    {
        // get the particles which matched the trigger conditions this frame
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        int numExit = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
        int numInside = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);

        //// iterate through the particles which entered the trigger and make them red
        //for (int i = 0; i < numEnter; i++)
        //{
        //    ParticleSystem.Particle p = enter[i];
        //    p.startColor = new Color32(255, 0, 0, 255);
        //    enter[i] = p;
        //}

        //// iterate through the particles which exited the trigger and make them green
        //for (int i = 0; i < numExit; i++)
        //{
        //    ParticleSystem.Particle p = exit[i];
        //    p.startColor = new Color32(0, 255, 0, 255);
        //    exit[i] = p;
        //}

        for(int i = 0; i < numInside; i++)
        {
            ParticleSystem.Particle p = inside[i];
            ParticleSystem.ShapeModule the_shape = ps.shape;
            the_shape.radius = shorten_radius;
            inside[i] = p;

        }

        // re-assign the modified particles back into the particle system
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);

    }
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

// used to set footsteps sound to play dependent on 
// the object tag for a third person character
public class FootstepsThirdPerson : MonoBehaviour {

    private float distance = 0.1f;
    // list of groundtypes (has a name and an array of sounds)
    private float material = 1.0f;
    

    void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down * distance, out hit))
        {
            if(hit.collider)
            {
                switch(hit.collider.tag)
                {
                    case "Grass":
                        material = 2.0f;
                        break;
                    case "Wood":
                        material = 3.0f;
                        break;
                    case "Stone":
                        material = 4.0f;
                        break;
                    case "Mud":
                        material = 1.0f;
                        break;
                    default:
                        material = 1.0f;
                        break;
                }
            }
        }

    }

    // function called directly from animation events when 
    // player animation steps(must be set up in each animation used)
    private void PlayStep(string path)
    {
        FMOD.Studio.EventInstance Footsteps = FMODUnity.RuntimeManager.CreateInstance(path);
        Footsteps.setParameterByName("Material", material);
        Footsteps.start();
        Footsteps.release();
    }
}


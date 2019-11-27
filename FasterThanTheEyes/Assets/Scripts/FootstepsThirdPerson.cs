using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

// used to set footsteps sound to play dependent on 
// the object tag for a third person character
public class FootstepsThirdPerson : MonoBehaviour {

    private float distance = 0.1f;
    private float material = 1.0f;
	// Update is called once per frame
	void FixedUpdate () {
        RaycastHit hit;
        if(Physics.Raycast(GetComponent<Transform>().position, Vector3.down * distance, out hit))
        {
            switch(hit.collider.tag)
            {
                case "Mud":
                    material = 1.0f;
                    break;
                case "Grass":
                    material = 2.0f;
                    break;
                case "Wood":
                    material = 3.0f;
                    break;
                case "Stone":
                    material = 4.0f;
                    break;
                case "Metal":
                    material = 5.0f;
                    break;
                default:
                    material = 1.0f;
                    break;
            }
        }
	}


    
    // function called directly from animation events when 
    // player animation steps(must be set up in each animation used)
    private void PlayStep()
    {
       
        // pick & play a random footstep sound from the array,
        // excluding sound at index 0
        //int n = Random.Range(1, TPC.m_FootstepSounds.Length);
        //TPC.m_AudioSource.clip = TPC.m_FootstepSounds[n];
        //TPC.m_AudioSource.PlayOneShot(TPC.m_AudioSource.clip);
        //// move picked sound to index 0 so it's not picked next time
        //TPC.m_FootstepSounds[n] = TPC.m_FootstepSounds[0];
        //TPC.m_FootstepSounds[0] = TPC.m_AudioSource.clip;
    }
}


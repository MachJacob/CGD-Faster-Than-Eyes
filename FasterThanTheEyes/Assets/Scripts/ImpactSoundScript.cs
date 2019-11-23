using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Uses tags to decide which sound to play on impact with another 
// object(Tag should match a name in the list of sounds to play
// or the default sound will play)
public class ImpactSoundScript : MonoBehaviour
{

    // velocity to volume modifier
    private float velToVol = 0.5F;
    private float velocityClipSplit = 10F;

    private float impactWeapon;
    private float impactHit;

    // Use this for initialization
    void Awake()
    {
        switch(tag)
        {
            case "Sword":
                impactWeapon = 1.0f;
                break;
            case "TwoHandedSword":
                impactWeapon = 2.0f;
                break;
            case "Magic":
                impactWeapon = 3.0f;
                break;
            default:
                impactWeapon = 1.0f;
                break;
        }
    }

	
	// Update is called once per frame
	void Update () {
		
	}

    // decides which sound to play and where to play it in the world
    // on impact by searching for the tag of the object and 
    // attempting to match it to a name on the list of sounds
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Sword":
                impactWeapon = 1.0f;
                break;
            case "TwoHandedSword":
                impactWeapon = 2.0f;
                break;
            case "Shield":
                impactWeapon = 3.0f;
                break;
            case "Wood":
                impactWeapon = 3.0f;
                break;
            case "Metal":
                impactWeapon = 3.0f;
                break;
            case "Grass":
                impactWeapon = 3.0f;
                break;
            case "Mud":
                impactWeapon = 3.0f;
                break;
            default:
                impactWeapon = 1.0f;
                break;
        }
        // calculate volume depending on impact velocity
        float hitVol = collision.relativeVelocity.magnitude * velToVol;

        // "setParameterValue" is showing up as red
        PlayImpact(hitVol);
    }

    // plays a random sound from the array at the set pitch and volume
    private void PlayImpact(float hitVol)
    {
        
    }
}

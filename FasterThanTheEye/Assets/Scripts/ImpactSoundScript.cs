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

    private float impactWeapon = 1.0f;
    private float impactHit = 1.0f;


    // Use this for initialization
    void Awake()
    {
        switch (tag)
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
    
	

    // decides which sound to play and where to play it in the world
    // on impact by searching for the tag of the object and 
    // attempting to match it to a name on the list of sounds
    private void OnCollisionEnter(Collision collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Shield":
                impactHit = 1.0f;
                break;
            case "Sword":
                impactHit = 2.0f;
                break;
            case "TwoHandedSword":
                impactHit = 3.0f;
                break;
            case "Human":
                impactHit = 4.0f;
                break;
            case "Wood":
                impactHit = 5.0f;
                break;
            case "Stone":
                impactHit = 6.0f;
                break;
            case "Grass":
                impactHit = 7.0f;
                break;
            default:
                impactHit = 1.0f;
                break;
        }
        // calculate volume depending on impact velocity
        float hitVol = collision.relativeVelocity.magnitude * velToVol;

        PlayImpact(hitVol, collision.transform.position);
    }

    private void PlayImpact(float hitVol, Vector3 position)
    {
        FMOD.Studio.EventInstance impactSound = FMODUnity.RuntimeManager.CreateInstance("event;/SFX/ImpactSound");
        impactSound.setParameterByName("ImpactWeapon", impactWeapon);
        impactSound.setParameterByName("ImpactHit", impactHit);
        impactSound.setParameterByName("Velocity", hitVol);
        impactSound.start();
        impactSound.release();
    }
}
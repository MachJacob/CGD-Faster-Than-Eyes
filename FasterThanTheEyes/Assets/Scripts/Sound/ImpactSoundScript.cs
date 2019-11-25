using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Uses tags to decide which sound to play on impact with another 
// object(Tag should match a name in the list of sounds to play
// or the default sound will play)
public class ImpactSoundScript : MonoBehaviour
{

    [FMODUnity.EventRef]
    public string ImpactEvent;
    FMOD.Studio.EventInstance Impact;
    // velocity to volume modifier
    private float velToVol = 0.5F;

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
                impactHit = 1.0f;
                break;
            case "TwoHandedSword":
                impactHit = 2.0f;
                break;
            case "Shield":
                impactHit = 3.0f;
                break;
            case "Wood":
                impactHit = 4.0f;
                break;
            case "Metal":
                impactHit = 5.0f;
                break;
            case "Boss":
                impactHit = 6.0f;
                break;
            case "SwordEnemy":
                impactHit = 7.0f;
                break;
            case "SpellCaster":
                impactHit = 8.0f;
                break;
            case "Player":
                impactHit = 9.0f;
                break;
            default:
                impactHit = 10.0f;
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

        Impact = FMODUnity.RuntimeManager.CreateInstance(ImpactEvent);
        Impact.setParameterByName("Velocity", hitVol);
        Impact.setParameterByName("Weapon", impactWeapon);
        Impact.setParameterByName("ObjectHit", impactHit);

        Impact.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));

        Impact.start();
        Impact.release();

    }
}

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
    
    // pitch range to randomly play sound at 
    private float lowPitchRange = .75F;
    private float highPitchRange = 1.5F;

    // array of audioclips to choose from for the relevant type
    public AudioClip[] impactSounds;

    // list of samples to play when bullet hits the surface
    public List<ObjectType> objectTypes = new List<ObjectType>();
    private AudioSource source;
    // Use this for initialization
    void Start ()
    {
        source = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // decides which sound to play and where to play it in the world
    // on impact by searching for the tag of the object and 
    // attempting to match it to a name on the list of sounds
    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < objectTypes.Count; i++)
        {
            if (this.transform.tag == objectTypes[i].name)
            {
                SetObjectTypes(objectTypes[i]);
            }
        }
        source.pitch = Random.Range(lowPitchRange, highPitchRange);
        // calculate volume depending on impact velocity
        float hitVol = collision.relativeVelocity.magnitude * velToVol;
        PlayImpact(hitVol);
    }

    // sets the impact sound to play
    public void SetObjectTypes(ObjectType hitObject)
    {
        impactSounds = hitObject.impactSounds;
    }

    // plays a random sound from the array at the set pitch and volume
    private void PlayImpact(float hitVol)
    {
        int n = Random.Range(1, impactSounds.Length);
        source.clip = impactSounds[n];
        source.PlayOneShot(source.clip, hitVol);

        impactSounds[n] = impactSounds[0];
        impactSounds[0] = source.clip;
    }
}
// list of sounds
[System.Serializable]
public class ObjectType
{
    public string name;
    public AudioClip[] impactSounds;
}

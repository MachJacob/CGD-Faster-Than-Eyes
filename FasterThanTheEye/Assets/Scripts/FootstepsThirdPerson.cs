using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

// used to set footsteps sound to play dependent on 
// the object tag for a third person character
public class FootstepsThirdPerson : MonoBehaviour {

    // list of groundtypes (has a name and an array of sounds)
    public List<GroundTypeThirdPerson> GroundTypes = new List<GroundTypeThirdPerson>();
    // the player
    public ThirdPersonCharacter TPC;
    // Use this for initialization
    void Start () {
        SetGroundType(GroundTypes[0]);
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    // checks the tag of the object the player hits
    // and sets the array on the characters footstep sound array
    // the matching sound s from the list
    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < GroundTypes.Count; i++)
        {
            if (collision.transform.tag == GroundTypes[i].name)
            {
                SetGroundType(GroundTypes[i]);
            }
        }
    }

    // sets the sounds in the first player sound array
    public void SetGroundType(GroundTypeThirdPerson ground)
    {
       // TPC.m_FootstepSounds = ground.footstepsounds;
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

[System.Serializable]
public class GroundTypeThirdPerson
{
    public string name;
    public AudioClip[] footstepsounds;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourSoundsScript : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string ArmourSoundEvent;
    FMOD.Studio.EventInstance ArmourSound;

    private float characterType;

    void Awake()
    {
        switch(gameObject.tag)
        {
            case "Player":
                characterType = 1.0f;
                break;
            case "SwordEnemy":
                characterType = 2.0f;
                break;
            case "SpellCaster":
                characterType = 3.0f;
                break;
            case "Boss":
                characterType = 4.0f;
                break;
        }
        if (SceneManagerFTTE.fmodEnable)
        {
            ArmourSound = FMODUnity.RuntimeManager.CreateInstance(ArmourSoundEvent);
            ArmourSound.setParameterByName("CharacterType", characterType);
            ArmourSound.setParameterByName("Velocity", GetComponent<Rigidbody>().velocity.magnitude);

            ArmourSound.start();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManagerFTTE.fmodEnable)
        {
            ArmourSound.setParameterByName("Velocity", GetComponent<Rigidbody>().velocity.magnitude);
        }
    }

    private void OnDestroy()
    {
        if (SceneManagerFTTE.fmodEnable)
        {
            ArmourSound.release();
        }
    }
}

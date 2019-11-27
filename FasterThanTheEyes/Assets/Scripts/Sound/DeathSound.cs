using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string DeathEvent;
    FMOD.Studio.EventInstance Death;
    float characterType;
    // Start is called before the first frame update
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
    }
    public void PlayDeathSound()
    {
        if (SceneManagerFTTE.fmodEnable)
        {
            Death = FMODUnity.RuntimeManager.CreateInstance(DeathEvent);
            Death.setParameterByName("CharacterType", characterType);

            Death.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));

            Death.start();
            Death.release();
        }

    }
}

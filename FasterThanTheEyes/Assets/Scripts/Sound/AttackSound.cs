using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string AttackEvent;
    FMOD.Studio.EventInstance Attack;
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
    public void PlayAttackSound(float attack)
    {
        Attack = FMODUnity.RuntimeManager.CreateInstance(AttackEvent);
        Attack.setParameterByName("CharacterType", characterType);
        Attack.setParameterByName("Attack", attack);

        Attack.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));

        Attack.start();
        Attack.release();
    }
}

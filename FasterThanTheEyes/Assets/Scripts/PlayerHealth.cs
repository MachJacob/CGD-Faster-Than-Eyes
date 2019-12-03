using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerHealth : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string BreathingEvent;
    FMOD.Studio.EventInstance Breathing;
    [SerializeField]
    public int health = 3;

    [SerializeField] HealthHeartScript hhs;
    // Start is called before the first frame update
    void Awake()
    {
        health = 3;
        if (SceneManagerFTTE.fmodEnable)
        {
        Breathing = FMODUnity.RuntimeManager.CreateInstance(BreathingEvent);
        Breathing.setParameterValue("Health", health);
        Breathing.start();
        }

    }

    public void Update()
    {

        Breathing.setParameterValue("Velocity", GetComponent<Rigidbody>().velocity.magnitude);
        //    if(Input.GetKeyDown(KeyCode.K))
        //    {
        //        DamageHealth(10);
        //    }
    }

    public float GetHealth()
    {
        return health;
    }

    public void SetHealth(int amount)
    {
        health = amount;
       
    }

    public void AdjustHealth(int amount)
    {
        health += amount;
        if (SceneManagerFTTE.fmodEnable)
        {
            Breathing.setParameterValue("Health", health);


            if (health <= 0)
            {
                Breathing.release();

            }
        }

        if (amount < 0)
        {
            
            
        }
    }

    public void DamageHealth(int amount)
    {
        //
        // Use DamageHealth function for taking hits from enemies!!!
        //
        AdjustHealth(Mathf.Abs(amount) * -1);
        OnReceiveDamage();
        
    }

    public virtual void OnReceiveDamage()
    {
        PlayerScore.DecreaseScore();
    }
}

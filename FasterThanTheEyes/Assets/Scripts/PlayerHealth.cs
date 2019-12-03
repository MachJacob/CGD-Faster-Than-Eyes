using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerHealth : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string BreathingEvent;
    FMOD.Studio.EventInstance Breathing;
    [SerializeField]
    private ImageShake imgShake;
    [SerializeField]
    private HealthBarHit hbh;

    [SerializeField]
    public float health = 4.0f;
    // Start is called before the first frame update
    void Awake()
    {
        health = 3.0f;
        if (SceneManagerFTTE.fmodEnable)
        {
        Breathing = FMODUnity.RuntimeManager.CreateInstance(BreathingEvent);
        Breathing.setParameterByName("Health", health);
        Breathing.start();
        }

    }

    public void Update()
    {

        //    if(Input.GetKeyDown(KeyCode.K))
        //    {
        //        DamageHealth(10);
        //    }
    }

    public float GetHealth()
    {
        return health;
    }

    public void SetHealth(float amount)
    {
        health = amount;
        hbh.UpdateHealthBarHit(amount / 100.0f);
    }

    public void AdjustHealth(float amount)
    {
        health += amount;
        if (SceneManagerFTTE.fmodEnable)
        {
            Breathing.setParameterByName("Health", health);


            if (health <= 0)
            {
                Breathing.release();

            }
        }

        if (amount < 0.0f)
        {
            imgShake.SetShake(1.0f, 15.0f, 1.0f);
            hbh.UpdateHealthBarHit(health / 100.0f);
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

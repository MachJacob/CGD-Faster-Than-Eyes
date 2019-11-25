using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private ImageShake imgShake;
    [SerializeField]
    private HealthBarHit hbh;

    [SerializeField]
    public int health = 0;
    // Start is called before the first frame update
    void Awake()
    {
        health = 100;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            DamageHealth(10);
        }

        if(Input.GetKeyUp(KeyCode.J))
        {

        }
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int amount)
    {
        health = amount;
        hbh.UpdateHealthBarHit(amount / 100.0f);
    }

    public void AdjustHealth(int amount)
    {
        health += amount;
        if (amount < 0)
        {
            imgShake.SetShake(1.0f, 15.0f, 1.0f);
            hbh.UpdateHealthBarHit(amount / 100.0f);
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

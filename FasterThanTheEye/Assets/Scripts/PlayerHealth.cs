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
}

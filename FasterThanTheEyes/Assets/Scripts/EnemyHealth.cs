using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int health;

    public int GetHealth()
    {
        return health;
    }
    public void Hit()
    {
        health--;

        if (health <= 0)
        {
            GetComponent<EnemyMovement>().Death();
        }
    }

}

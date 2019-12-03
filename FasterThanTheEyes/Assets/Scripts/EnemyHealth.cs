using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int health = 4;

    public int GetHealth()
    {
        return health;
    }

    private void Update()
    {
        if(health == 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void Hit()
    {
        health--;

        if (health == 0)
        {
            GetComponentInParent<SceneManagerFTTE>().numEnemiesKilled++;
            if (GetComponent<EnemyMovement>() != null)
            {
                GetComponent<EnemyMovement>().Death();
            }
            else if (GetComponent<EnemyCaster>() != null)
            {
                GetComponent<EnemyCaster>().Death();
            }

        }
        else
        {
            if (GetComponent<EnemyMovement>() != null)
            {
                GetComponent<EnemyMovement>().Hit();
            }
            else if (GetComponent<EnemyCaster>() != null)
            {
                GetComponent<EnemyCaster>().Hit();
            }
        }
    }

}

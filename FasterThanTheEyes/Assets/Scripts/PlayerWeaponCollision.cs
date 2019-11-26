using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnHit(Collider collision)
    {
        var colliderGO = collision.gameObject;
        switch(colliderGO.tag)
        {
            case "Human" :
                //Play the Hit Sound
                //Deal Damage
                StartCoroutine(HitTimer());
                //Increase pScore

                break;
            case "Metal" :
                //play metal hit sounds
                break;
                
                //etc....
        }
          
    }

    private void OnTriggerEnter(Collider collision)
    {
        //if(Attacking)
        //{ 
        OnHit(collision);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(HitCounter);
        Debug.Log(HitTimerReset);
    }


    private bool HitTimerReset = false;
    private int HitCounter = 0;
    IEnumerator HitTimer()
    {
        
        HitTimerReset = true;
        yield return new WaitForSeconds(2);
        if(HitTimerReset)
        {
            HitCounter++;
            PlayerScore.IncreaseScore(HitCounter);
            HitTimerReset = false;
        }
        else
        {
            HitCounter = 0;
        }
        yield return null;
    }
}

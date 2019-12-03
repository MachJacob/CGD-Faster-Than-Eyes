using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponCollision : MonoBehaviour
{
    public ParticleSystem bloodSystem;
    public ParticleSystem sparkSystem;
    private ParticleSystem systemInstance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnHit(Collider collision)
    {
        var colliderGO = collision.gameObject;
        switch(colliderGO.tag)
        {
            case "SpellCaster" :
                //Play the Hit Sound
                //Deal Damage
                
                StartCoroutine(HitTimer());
                systemInstance = Instantiate(bloodSystem, collision.gameObject.transform.position, collision.gameObject.transform.rotation, collision.gameObject.transform);
                systemInstance.Play();
                Destroy(systemInstance, 5);
                //Increase pScore

                colliderGO.GetComponent<EnemyHealth>().Hit();
                break;
            case "SwordEnemy":
                //Play the Hit Sound
                //Deal Damage
                StartCoroutine(HitTimer());
                systemInstance = Instantiate(bloodSystem, collision.gameObject.transform.position, collision.gameObject.transform.rotation, collision.gameObject.transform);
                systemInstance.Play();
                Destroy(systemInstance, 5);
                colliderGO.GetComponent<EnemyHealth>().Hit();
                //Increase pScore

                break;
            case "Boss":
                //Play the Hit Sound
                //Deal Damage
                StartCoroutine(HitTimer());
                systemInstance = Instantiate(bloodSystem, collision.gameObject.transform.position, collision.gameObject.transform.rotation, collision.gameObject.transform);
                systemInstance.Play();
                Destroy(systemInstance, 5);
                colliderGO.GetComponent<EnemyHealth>().Hit();
                //Increase pScore

                break;
            case "Sword" :
                //play metal hit sounds
                systemInstance = Instantiate(sparkSystem, collision.gameObject.transform.position, collision.gameObject.transform.rotation, collision.gameObject.transform);
                systemInstance.Play();
                Destroy(systemInstance, 5);
                break;
            case "Shield":
                //play metal hit sounds
                systemInstance = Instantiate(sparkSystem, collision.gameObject.transform.position, collision.gameObject.transform.rotation, collision.gameObject.transform);
                systemInstance.Play();
                Destroy(systemInstance, 5);
                break;
            case "TwoHandedSword":
                //play metal hit sounds
                systemInstance = Instantiate(sparkSystem, collision.gameObject.transform.position, collision.gameObject.transform.rotation, collision.gameObject.transform);
                systemInstance.Play();
                Destroy(systemInstance, 5);
                break;

                //etc....
        }
        Debug.Log(colliderGO.GetComponent<EnemyHealth>().GetHealth()); 
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
        //Debug.Log(HitCounter);
        //Debug.Log(HitTimerReset);
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

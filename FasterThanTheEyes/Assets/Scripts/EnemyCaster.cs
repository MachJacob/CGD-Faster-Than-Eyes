using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCaster : MonoBehaviour
{
    public GameObject Player;
    public GameObject projectile;
    public Animator anim;
    public float range = 10.0f;
    public float moveSpeed = 2.0f;

    public float AttackCooldownCounter = 5.0f;
    private bool coolingdown = true;
    private bool attackOver;
    bool played = true;

    private Vector3 spawnPosition;

    void Start()
    {
        attackOver = true;
        spawnPosition = new Vector3(Random.insideUnitSphere.x * (Player.transform.position.x + range),
         Player.transform.position.y, Random.insideUnitSphere.z * (Player.transform.position.z + range));
    }

    // Update is called once per frame
    void Update()
    {
        //move towards a location around the player based on range value
        transform.position = Vector3.Lerp(transform.position, spawnPosition, Time.deltaTime * moveSpeed);
        //look at player
        transform.LookAt(Player.transform);

        //running sound here
        //running animations here

        if (!coolingdown)
        {
            StartCoroutine(Attack());
            //Attack has ended
        }

        AttackCooldownCounter -= Time.deltaTime;
        if (AttackCooldownCounter <= 0)
        {
            coolingdown = false;
        }

    }
    private IEnumerator Attack()
    {
        bool stepone = true;
        bool steptwo = false;
        bool stepthree = false;
        if (stepone)
        {
            //do step 1 animation - start cast
            if (played)
            {
                anim.SetBool("Attack", true);
                yield return new WaitForEndOfFrame();
                anim.SetBool("Attack", false);
                played = false;
            }
            //play anim sound HERE

            yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length
                + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            Debug.Log("StartCastAnim Finished");

            steptwo = true;
            stepone = false;
        }
        if (steptwo)
        {
            //do step 2 animation - raise rock

            //play anim sound HERE
            yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length
                + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

            stepthree = true;
            steptwo = false;

        }
        if (stepthree)
        {
            played = true;
            AttackCooldownCounter = 5.0f;
            coolingdown = stepthree = true;
        }
    }
}

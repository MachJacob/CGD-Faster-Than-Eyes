using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCaster : MonoBehaviour
{
    public GameObject Player;
    public GameObject projectile;
    private Transform targetStart, target;
    public Animator anim;
    public float range = 10.0f;
    public float moveSpeed = 2.0f;

    public float AttackCooldownCounter = 5.0f;
    private bool coolingdown = true;
    private bool attackOver;
    bool played = true;
    bool spawned = false;
    public bool shootrock = false;

    private Vector3 spawnPosition;

    void Start()
    {
        target = gameObject.transform.Find("Target");
        targetStart = gameObject.transform.Find("TargetStart");
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
            Debug.Log("Starting attack routine");
            StartCoroutine(Attack());
            spawned = false;
            //Attack has ended
        }
        else if (attackOver)
        {
            AttackCooldownCounter -= Time.deltaTime;
            if (AttackCooldownCounter <= 0)
            {
                coolingdown = false;
            }
        }

    }
    private IEnumerator Attack()
    {
        coolingdown = true;
        attackOver = false;
        bool stepone = true;
        bool steptwo = false;
        bool stepthree = false;
        Debug.Log("Bools:" + stepone + steptwo + stepthree);
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

            if (stepone && !spawned)
            {
                Instantiate(projectile, targetStart.position, Quaternion.identity, this.gameObject.transform);
                spawned = true;
            }

            yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length
                + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            Debug.Log("StartCastAnim Finished");

            steptwo = true;
            stepone = false;
        }
        if (steptwo)
        {
            //do step 2 animation - raise rock
            shootrock = true;
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("RaiseObject"))
            {
                //curr_proj.transform.position = Vector3.Lerp(curr_proj.transform.position, target.position, Time.deltaTime * moveSpeed);
                //curr_proj.transform.rotation = Random.rotation;
            }
            //apply glow to stone
            //play anim sound HERE
            yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length
                + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            Debug.Log("RaiseRock Finished");

            //curr_proj.transform.position = Vector3.Lerp(curr_proj.transform.position, Player.transform.position, Time.deltaTime * 5);

            stepthree = true;
            steptwo = false;
        }
        if (stepthree)
        {
            shootrock = false;
            yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length
                 + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            played = true;
            attackOver = true;
            AttackCooldownCounter = 5.0f;
            coolingdown = true;
            stepthree = false;
        }
    }
}

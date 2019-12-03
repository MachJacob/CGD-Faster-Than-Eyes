using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float radius = 25f;
    //circle radius
    /// Random.insideUnitSphere * 5
    public float speed = 1f;
    public bool CentredToObject = true;
    public Vector3 offset;
    //exact offset values, x is negative
    public GameObject Player;
    public Animator anim;
    //object to circle around
    public float AttackCooldownCounter = 5.0f;

    private float attackcooldownnew = 5.0f;
    private bool coolingdown = true;
    private bool playercollided = false;
    private bool attackOver;
    private Vector3 target;
    private bool pause;
    bool enable;

    private bool jumpAttack;
    int idk;

    private Vector3 spawnPosition;

    void Awake()
    {
        anim = GetComponent<Animator>();
        attackcooldownnew = AttackCooldownCounter;
        attackOver = true;
        enable = false;
    }

    void Update()
    {
        if (enable)
        {
            transform.position = new Vector3(transform.position.x, Player.transform.position.y, transform.position.z);

            if (jumpAttack)
            {
                jumpAttack = false;
                anim.SetBool("Jump", jumpAttack);
                anim.SetBool("AttackOne", jumpAttack);
            }

            //if (CentredToObject)
            //{
            //    offset = Player.transform.position;
            //    offset.x = -Player.transform.position.x;
            //}
            if (!coolingdown)
            {
                target = Player.transform.position;
                float dist = Vector3.Distance(Player.transform.position, transform.position);
                if (dist > 20)
                {
                    anim.SetBool("Run", true);
                    anim.SetFloat("Turn", 0);
                    transform.LookAt(target);
                }
                else
                {
                    anim.SetBool("Run", false);
                    Attack();
                }

                //Attack has ended
            }
            else if (pause)
            {
                attackcooldownnew -= Time.deltaTime;
                if (attackcooldownnew <= (AttackCooldownCounter - 2))
                {
                    attackcooldownnew = AttackCooldownCounter;
                    pause = false;
                }
                anim.SetFloat("Forward", 0);
                anim.SetFloat("Turn", 0);
            }
            else if (attackOver && !pause)
            {
                // anim.SetFloat("Forward", 1.0f);
                //Enemy returns to circular moving pattern HERE

                anim.SetFloat("Forward", 1);
                anim.SetFloat("Turn", 1);
                transform.LookAt(Player.transform);
                Vector3 lerpPos = new Vector3((radius * Mathf.Cos(Time.time * speed)),
                                    transform.position.y,
                                    (radius * Mathf.Sin(Time.time * speed))) + Player.transform.position;
                transform.position = Vector3.Lerp(transform.position, lerpPos, Time.deltaTime * 1.0f);

                //if ((transform.position.x <= spawnPosition.x + 1 && transform.position.z <= spawnPosition.z + 1) &&
                //    (transform.position.x >= spawnPosition.x - 1 && transform.position.z >= spawnPosition.z - 1))
                //{
                //    anim.SetFloat("Forward", 0);
                //}
                //enemy walk animation/ sound

                attackcooldownnew -= Time.deltaTime;
                if (attackcooldownnew <= 0)
                {
                    coolingdown = false;
                }
                idk = 0;
                return;
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("GroundedRunning") && !anim.GetBool("Run"))
            {
                idk++;
                if (idk >= 5)
                {
                    coolingdown = false;
                }
            }
        }
    }
    private void Attack()
    {
        attackOver = false;
        coolingdown = true;

        //enemy starts running towards Player HERE
        //enemy charge animation
        //enemy charge sound
        jumpAttack = true;
        anim.SetBool("Jump", true);
        anim.SetBool("AttackOne", true);
        //transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * 1);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "SwordEnemy")
        {
            //if enemies colllide with each other, adjust their radius
            radius = Random.Range(radius - 5, radius + 5);
        }
    }

    public void AttackEnd()
    {
        attackcooldownnew = AttackCooldownCounter;
        attackOver = true;
        pause = true;
    }
    public void Death()
    {
        anim.SetBool("Death", true);
        
    }
    public void Hit()
    {
        anim.SetBool("Hit", true);

    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void InitPlayer(GameObject _player)
    {
        Player = _player;
        //if (CentredToObject)
        //{
        //    offset = Player.transform.position;
        //    offset.x = -Player.transform.position.x;
        //}
        spawnPosition = new Vector3((Random.insideUnitSphere.x * radius) + Player.transform.position.x + radius,
        transform.position.y, (Random.insideUnitSphere.z * radius) + Player.transform.position.z + radius);
        enable = true;
    }
}

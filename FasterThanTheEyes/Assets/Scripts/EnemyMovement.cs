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

    public float counter = 0.0f;
    private float attackcooldownnew = 5.0f;
    private bool coolingdown = true;
    private bool playercollided = false;
    private bool attackOver;

    private Vector3 spawnPosition;

    void Start()
    {
        attackcooldownnew = AttackCooldownCounter;
        attackOver = true;
        if (CentredToObject)
        {
            offset = Player.transform.position;
            offset.x = -Player.transform.position.x;
        }
        spawnPosition = new Vector3((Random.insideUnitSphere.x * radius) + Player.transform.position.x + radius,
        transform.position.y, (Random.insideUnitSphere.z * radius) + Player.transform.position.z + radius);
    }

    void FixedUpdate()
    {
        anim.SetFloat("Forward", 1);
        anim.SetFloat("Turn", 1);
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        transform.LookAt(Player.transform);
        counter += Time.deltaTime;
        if (counter >= 2.0f)
        {

            spawnPosition = new Vector3((Random.insideUnitSphere.x * radius) + Player.transform.position.x + radius,
            transform.position.y, (Random.insideUnitSphere.z * radius) + Player.transform.position.z + radius);
        }

        if (CentredToObject)
        {
            offset = Player.transform.position;
            offset.x = -Player.transform.position.x;
        }

        if (!coolingdown)
        {
            StartCoroutine(Attack());
            //Attack has ended
        }

        else if (attackOver)
        {
            // anim.SetFloat("Forward", 1.0f);
            //Enemy returns to circular moving pattern HERE

            transform.position = Vector3.Lerp(transform.position, new Vector3((radius * Mathf.Cos(Time.time * speed)) + offset.x,
                                transform.position.y,
                                (radius * Mathf.Sin(Time.time * speed)) + offset.z), Time.deltaTime * 1.0f);

            if ((transform.position.x <= spawnPosition.x + 1 && transform.position.z <= spawnPosition.z + 1) &&
                (transform.position.x >= spawnPosition.x - 1 && transform.position.z >= spawnPosition.z - 1))
            {
                anim.SetFloat("Forward", 0);
            }
            //enemy walk animation/ sound

            attackcooldownnew -= Time.deltaTime;
            if (attackcooldownnew <= 0)
            {
                coolingdown = false;
            }
        }
    }
    private IEnumerator Attack()
    {
        attackOver = false;

        if (playercollided)
        {
            //Player is hit HERE
            //player hit sound
            //player hit animation
            attackcooldownnew = AttackCooldownCounter;
            coolingdown = true;
            attackOver = true;
        }
        else
        {
            //enemy starts running towards Player HERE
            //enemy charge animation
            //enemy charge sound
            anim.SetBool("Jump", true);
            anim.SetBool("AttackOne", true);
            yield return new WaitForEndOfFrame();
            anim.SetBool("Jump", false);
            anim.SetBool("AttackOne", false);
            transform.position = Vector3.Lerp(transform.position, Player.transform.position, Time.deltaTime * 2);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            playercollided = true;
            counter = 0.0f;
        }

        if (collision.collider.gameObject.tag == "Enemy")
        {
            //if enemies colllide with each other, adjust their radius
            radius = Random.Range(radius - 5, radius + 5);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            playercollided = false;
        }
    }

}

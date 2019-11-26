using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float radius = 10f;
    //circle radius
    /// Random.insideUnitSphere * 5
    public float speed = 1f;
    public bool CentredToObject = true;
    public Vector3 offset;
    //exact offset values, x is negative
    public GameObject Player;
    //object to circle around

    public float AttackCooldownCounter = 5.0f;
    private bool coolingdown = true;
    bool playercollided = false;
    private bool attackOver;

    void Start()
    {
        attackOver = true;
        if (CentredToObject)
        {
            offset = Player.transform.position;
            offset.x = -Player.transform.position.x;
        }
    }

    void FixedUpdate()
    {
        if (CentredToObject)
        {
            offset = Player.transform.position;
            offset.x = -Player.transform.position.x;
        }

        if (!coolingdown)
        {
            Attack();
        }
        else if (attackOver)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3((radius * Mathf.Cos(Time.time * speed)) + offset.x,
                                offset.y,
                                (radius * Mathf.Sin(Time.time * speed)) + offset.z), Time.time * 0.01f);

            AttackCooldownCounter -= Time.deltaTime;
            if (AttackCooldownCounter <= 0)
            {
                coolingdown = false;
            }
        }
    }

    private void Attack()
    {
        attackOver = false;

        if (playercollided)
        {
            AttackCooldownCounter = 5.0f;
            coolingdown = true;
            attackOver = true;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, Player.transform.position, Time.time * 0.01f);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //if enemies colllide with each other, adjust their radius
            radius = Random.Range(radius - 5, radius + 5);
        }
        if (other.gameObject.tag == "Player")
        {
            playercollided = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playercollided = false;
        }
    }

}

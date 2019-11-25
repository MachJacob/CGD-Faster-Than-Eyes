using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float radius = -10f;
    public float speed = 1f;
    public bool offsetIsCenter = true;
    public Vector3 offset;
    public GameObject Player;

    void Start()
    {
        if (offsetIsCenter)
        {
            offset = transform.position;
            offset.x = -transform.position.x;
        }
    }

    void Update()
    {
        transform.position = new Vector3((radius * Mathf.Cos(Time.time * speed)) + offset.x, offset.x, (radius * Mathf.Sin(Time.time * speed)) + offset.z);
    }

}

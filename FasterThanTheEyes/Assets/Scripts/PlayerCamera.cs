using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject player;
    [SerializeField]
    private Vector3 offset;
    void Awake()
    {
    }

    void Update()
    {
        transform.position = offset + player.transform.position;

    }
}

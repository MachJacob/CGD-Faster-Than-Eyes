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
        offset = new Vector3(0.0f, 25f, -20f);
    }

    void Update()
    {
        transform.position = offset + player.transform.position;

    }
}

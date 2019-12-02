using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject player;
    [SerializeField]
    private Vector3 offset = new Vector3(0f, 40f, -25f);
    void Awake()
    {
        
    }

    void Update()
    {
        transform.position = offset + player.transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasterProjectile : MonoBehaviour
{
    public float moveSpeed = 0.01f;
    private Transform Player;
    [SerializeField]
    Rigidbody rb;
    public GameObject target;
    private bool ready = false;
    public EnemyCaster ec;
    public int movetime = 8;
    Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        target = ec.transform.GetChild(0).gameObject;
        Invoke("Gravity", 4);
        Destroy(gameObject, movetime);
    }

    // Update is called once per frame
    void Update()
    {
        if (!ready && ec.shootrock)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * moveSpeed);
            transform.rotation = Random.rotation;
        }
        else if (ready)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos + new Vector3(-10,0,-10), Time.deltaTime * 2);
            ec.rockfired = true;
            ec.counter = 0.0f;
        }

    }
    void Gravity()
    {
        rb.useGravity = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //reduce Player HP
            Player.GetComponent<PlayerHealth>().DamageHealth(1);
            Debug.Log(Player.GetComponent<PlayerHealth>().GetHealth());
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Target")
        {
            //Debug.Log("Launching");
            ready = true;
            targetPos = Player.position + (Vector3.up * 5);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasterProjectile : MonoBehaviour
{
    public float moveSpeed = 0.01f;
    private Transform Player;
    [SerializeField]
    public GameObject target;
    private bool ready = false;
    public EnemyCaster ec;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        target = this.transform.parent.gameObject.transform.GetChild(0).gameObject;
        ec = this.transform.parent.gameObject.GetComponent<EnemyCaster>();
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

            transform.position = Vector3.Lerp(transform.position, Player.position, Time.deltaTime * 5);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //reduce Player HP
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Target")
        {
            Debug.Log("Launching");
            ready = true;
        }
    }
}

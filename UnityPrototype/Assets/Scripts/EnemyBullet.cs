using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] Transform player;
    Rigidbody rb;
    Vector3 redirect;
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        Vector3 newpos = player.position - gameObject.transform.position;
       
        newpos.Normalize();
        rb.AddForce(newpos * bulletSpeed);
        redirect = newpos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fish")
        {
            rb.AddForce(-redirect * 1000);
            gameObject.tag = "Reflected";
        }
        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}

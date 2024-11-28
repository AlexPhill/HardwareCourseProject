using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    bool shoot;
    [SerializeField]  bool istargeting;
    [SerializeField] Transform player;
    [SerializeField] float distance;
    [SerializeField] float distanceToShoot = 20f;
    bool cooldownl;

    [SerializeField] float bulletSpeed = 500f;
    // Start is called before the first frame update
    void Start()
    {
        shoot = true;
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //StartCoroutine(fire());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector3.Distance (player.position, gameObject.transform.position);
        if (distance < distanceToShoot)

        {
             
           
            if (shoot)
            {
                StartCoroutine(fire());
            }
        

        }
       
        
    }

    
    IEnumerator fire()
    {
        shoot = false;
        yield return new WaitForSeconds(1.5f);
        GameObject bulletInstance = Instantiate(bullet,gameObject.transform.position, Quaternion.identity);
        bulletInstance.GetComponent<EnemyBullet>().bulletSpeed = bulletSpeed;
        shoot = true;
    }
   
}

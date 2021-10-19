using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public int damage;
    public float speed;
    Enemy enemyHealth;
    public GameObject rocketExplosion;

    private void Start()
    {
        
        rb = GetComponent<Rigidbody>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Skinuti health enemyu
            Enemy enemyHealth = collision.gameObject.GetComponent<Enemy>();
            enemyHealth.health -= damage;
            Explode();
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag != "Enemy")
        {
            Destroy(this.gameObject);
            Explode();

        }
        else
        {
            Destroy(this.gameObject);
            Explode();
        }
       
    }
    private void Explode()
    {
            // --- Instantiate new explosion option. I would recommend using an object pool ---
            GameObject newExplosion = Instantiate(rocketExplosion, transform.position, rocketExplosion.transform.rotation, null);


    }

 }

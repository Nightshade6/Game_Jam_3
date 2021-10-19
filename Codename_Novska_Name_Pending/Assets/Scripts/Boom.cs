using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;
   
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Stvar" || other.gameObject.tag == "Enemy")
        {
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
            }

        } 

       
    }
    
}    

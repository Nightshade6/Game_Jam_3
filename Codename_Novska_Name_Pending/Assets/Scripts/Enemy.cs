using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10;


    private void Update()
    {
        if (health <= 0)
        {
            StartCoroutine(Cleaning());
        }
    }
    IEnumerator Cleaning()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

}

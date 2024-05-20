using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Threading;

public class YellowBall : MonoBehaviour
{
    public float explosionRadius;
    public float explosionForce;

    public GameObject explosionEffect;

    private bool exploded = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!exploded)
        {
            exploded = true;            
            Explode();          
        }
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D nearbyObject in colliders)
        {
            Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = (rb.transform.position - transform.position).normalized;

                rb.AddForce(direction * explosionForce, ForceMode2D.Impulse);               
            }
            
        }      
        Destroy(gameObject);
    }
}

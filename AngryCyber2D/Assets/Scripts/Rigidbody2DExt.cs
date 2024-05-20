using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public static class  Rb2DExt
{

     public static void AddExplosionForce(this Rigidbody2D rb, float explosionForce, Vector2 explosionPosition, float explosionRadius, float upwardsModifier = 0.0F, ForceMode2D mode = ForceMode2D.Force)
     {
        var explosionDir = rb.position - explosionPosition;
        var explosionDistance = explosionDir.magnitude;

        // Normalize without computing magnitude again
       if (upwardsModifier == 0)
       {
        explosionDir /= explosionDistance;
       }
       
       else
       {
        // From Rigidbody.AddExplosionForce doc:
        // If you pass a non-zero value for the upwardsModifier parameter, the direction
        // will be modified by subtracting that value from the Y component of the centre point.
        explosionDir.y += upwardsModifier;
        explosionDir.Normalize();
       }

        rb.AddForce(Mathf.Lerp(0, explosionForce, (1 - explosionDistance)) * explosionDir, mode);

     }
    //[SerializeField] private float _radius;
   // [SerializeField] private float _force;

   // public void OnCollisionEnter2D(Collision2D collision)
   // {
      //  if (collision.gameObject.CompareTag("Wall"))
      //  {
       //     Explosive();
       // }
   // }

   // private void Explosive()
   // {
     //   Collider2D[] overlappedColliders = Physics2D.OverlapCircleAll(transform.position, _radius);
     //   for (int i = 0; i < overlappedColliders.Length; i++)
     //   {
       //     Rigidbody2D rb = overlappedColliders[i].attachedRigidbody;
       //     if (rb)
       //     {
       //         rb.AddExplosionForce(_force, transform.position, _radius);
       //     }
     //   }
  // }

}


/*
 * Simple projectile which accelerates forward and despawns after some time.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    //Projectile speed and life
    private float speed = 10f;
    private float lifeTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Destroys after lifeTime (seconds)
        Destroy(this.gameObject, lifeTime);
        //Apply velocity forward
        rb.velocity = transform.up * speed;
    }

    //Accelerate the projectile as it moves (probably not wanted, keeping for potential idea)
    void FixedUpdate()
    {
        //rb.AddForce(transform.up * speed);
    }
}

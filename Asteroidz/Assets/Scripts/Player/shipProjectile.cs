using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 10f;
    private float lifeTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, lifeTime);
        rb.velocity = transform.up * speed;
    }

    void FixedUpdate()
    {
        //rb.AddForce(transform.up * speed);
    }
}

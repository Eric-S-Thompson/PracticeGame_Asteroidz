/*
 * Simple projectile which accelerates forward and despawns after some time.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectile
{
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

        //Collision occurs, ship is destroyed
        void OnTriggerEnter2D(Collider2D target)
        {
            if (target.tag != "Player" && target.tag != "GameController")
            {
                //Destroy this object
                Destroy(this.gameObject);
            }
        }
    }
}

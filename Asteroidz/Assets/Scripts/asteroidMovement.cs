using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidMovement : asteroidDumb
{
    public GameObject smallerAsteroids;

    void OnTriggerEnter2D(Collider2D target)
    {
        Debug.Log("Asteroid collided");
        if (target.tag == "PlayerProjectile")
        {
            Debug.Log("Projectile collided");
            Instantiate(smallerAsteroids, transform.position, transform.rotation);
            Instantiate(smallerAsteroids, transform.position, transform.rotation);
            Destroy(target.gameObject);
            Destroy(this.gameObject);
        }
    }
}

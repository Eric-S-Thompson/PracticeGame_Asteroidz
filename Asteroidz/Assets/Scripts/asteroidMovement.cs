/*
 * Movement implementation for our main asteroids, uses dumb asteroid movement
 * Splits into two smaller asteroids when hit
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidMovement : asteroidDumb
{
    public GameObject smallerAsteroids; //Store our dumb asteroid prefab which won't split when hit

    //Collision occurs, splits asteroid into two smaller ones
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "PlayerProjectile")
        {
            //Instantiate two smaller dumb asteroids at this object's position
            //We feed in rotation just to satisfy parameter requirement, the dumb asteroids generate their own random rotation
            Instantiate(smallerAsteroids, transform.position, transform.rotation);
            Instantiate(smallerAsteroids, transform.position, transform.rotation);
            //Destroy the projectile and this object
            Destroy(target.gameObject);
            Destroy(this.gameObject);
        }
    }
}

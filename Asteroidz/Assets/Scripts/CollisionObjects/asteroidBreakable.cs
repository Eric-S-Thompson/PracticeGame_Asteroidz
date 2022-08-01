/*
 * Implementation for our main, breakable asteroids, uses dumb asteroid movement
 * Splits into two smaller asteroids when hit
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using collisionObject;

public class asteroidBreakable : asteroidDumb
{
    public int numSmallerAsteroids; //Amount of smaller asteroids created
    public GameObject smallerAsteroids; //Store our dumb asteroid prefab which won't split when hit

    //Collision occurs, splits asteroid into two smaller ones
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "PlayerProjectile")
        {
            //Instantiate two smaller dumb asteroids at this object's position
            createAsteroids(2);
            //Destroy this object
            Destroy(this.gameObject);
        }
    }

    //Collision occurs with non-trigger object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Instantiate smaller dumb asteroids at this object's position
        createAsteroids(numSmallerAsteroids);
        //Destroy this object
        Destroy(this.gameObject);
    }

    //Instantiates some amount of dumb asteroids at this object's position
    void createAsteroids(int numAsteroids)
    {
        if (numAsteroids >= 0)
        {
            for (int i = 0; i < numAsteroids; i++)
            {
                //We feed in rotation just to satisfy parameter requirement, the dumb asteroids generate their own random rotation
                Instantiate(smallerAsteroids, transform.position, transform.rotation);
            }
        }
    }
}

/*
 * Simple asteroid which moves in a random direction and is destroyed when hit by an object with the "PlayerProjectile" tag
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace collisionObject
{
    public class asteroidDumb : MonoBehaviour
    {
        private Rigidbody2D rb;
        private float zRot; //Random initial direction the asteroid moves toward when being initialized
        private int reverseRot; //-1 or 1, determines if the asteroid moves clockwise or counterclockwise

        public float moveSpeed;
        public float rotateSpeed;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            //Generating random values for rotation and reverse direction
            zRot = randomRot();
            reverseRot = reverse();
            //Set the rotation
            transform.rotation = Quaternion.Euler(0, 0, zRot);
            //Put the object in motion
            rb.velocity = transform.up * moveSpeed;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            //Apply rotation
            transform.Rotate(Vector3.forward * rotateSpeed * reverseRot * Time.deltaTime);
        }

        //Generate random rotation between 0 and 360 degrees
        float randomRot()
        {
            return Random.Range(0f, 360f);
        }
        //Generates -1 or 1 to determine rotation direction
        int reverse()
        {
            return ((Random.Range(0, 2) == 0) ? 1 : -1);
        }

        //Collision occurs with trigger object
        void OnTriggerEnter2D(Collider2D target)
        {
            if (target.tag == "PlayerProjectile")
            {
                //Destroy this object
                Destroy(this.gameObject);
            }
        }
    }
}

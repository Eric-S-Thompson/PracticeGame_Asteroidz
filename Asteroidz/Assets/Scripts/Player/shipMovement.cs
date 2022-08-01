/*
 * Movement of the player's ship. The ship may accelerate forward, rotate, and fire projectiles.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace playerMovement
{
    public class shipMovement : MonoBehaviour
    {
        public bool debug = false; //Set to true to print debug info

        Animator animator;
        private Rigidbody2D rb;

        //Speed attributes
        public float rotateSpeed;
        public float moveSpeed;

        //Projectile attributes
        public GameObject playerProjectile;
        public float projectileOffset; //Distance from the center of the ship

        //Holds keyboard inputs from the player
        private float throttle = 0f;
        private float rotate = 0f;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            //Player has fired projectile
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(playerProjectile, transform.position + (transform.up * projectileOffset), transform.rotation);
            }
        }
        void FixedUpdate()
        {
            //Get player inputs
            throttle = Input.GetAxis("Vertical");
            rotate = Input.GetAxis("Horizontal");

            //Printing values of player input
            if (debug)
            {
                Debug.Log("Throttle: " + throttle);
                Debug.Log("Rotation: " + rotate);
            }

            //Apply throttle
            rb.AddForce(transform.up * moveSpeed * throttle);
            //Animate flames behind the ship if moving forward
            if (throttle > 0f)
            {
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
            //Apply rotation
            transform.Rotate(Vector3.forward * rotateSpeed * -rotate * Time.deltaTime);
        }

        //Collision occurs, ship is destroyed
        void OnTriggerEnter2D(Collider2D target)
        {
            Debug.Log("Collided with " + target.name);
            if (target.tag != "PlayerProjectile" && target.tag != "GameController")
            {
                //Destroy this object
                Destroy(this.gameObject);
            }
        }
    }
}

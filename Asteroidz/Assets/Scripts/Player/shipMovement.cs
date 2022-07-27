using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMovement : MonoBehaviour
{
    public bool debug = false;

    Animator animator;
    private Rigidbody2D rb;

    public float rotateSpeed;
    public float moveSpeed;

    public GameObject projectile;
    public float projectileOffset;

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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, transform.position + (transform.up * projectileOffset), transform.rotation);
        }
    }
    void FixedUpdate()
    {
        throttle = Input.GetAxis("Vertical");
        rotate = Input.GetAxis("Horizontal");

        //Printing values of player input
        if(debug)
        {
            Debug.Log("Throttle: " + throttle);
            Debug.Log("Rotation: " + rotate);
        }

        //Apply throttle
        rb.AddForce(transform.up * moveSpeed * throttle);
        //Animate if moving forward
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
}

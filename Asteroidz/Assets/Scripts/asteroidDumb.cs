using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidDumb : MonoBehaviour
{
    private Rigidbody2D rb;
    private float zRot;
    private int reverseRot;

    public float moveSpeed;
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        zRot = randomRot();
        reverseRot = reverse();

        transform.rotation = Quaternion.Euler(0, 0, zRot);
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

    void OnTriggerEnter2D(Collider2D target)
    {
        Debug.Log("Asteroid collided");
        if (target.tag == "PlayerProjectile")
        {
            Debug.Log("Projectile collided");
            Destroy(target.gameObject);
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounds : MonoBehaviour
{
    public float left = -9.9f;
    public float right = 9.9f;
    public float up = 4.9f;
    public float down = -4.9f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exit bounds");
        float x = other.gameObject.transform.position.x;
        float y = other.gameObject.transform.position.y;
        if (x < left)
        {
            other.gameObject.transform.position = new Vector3(right, y, 0f);
        }
        else if (x > right)
        {
            other.gameObject.transform.position = new Vector3(left, y, 0f);
        }
        if (y < down)
        {
            other.gameObject.transform.position = new Vector3(x, up, 0f);
        }
        else if (y > up)
        {
            other.gameObject.transform.position = new Vector3(x, down, 0f);
        }
    }
}

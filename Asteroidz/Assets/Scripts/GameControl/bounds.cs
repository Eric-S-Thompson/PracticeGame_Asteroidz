/**
 * Keeps objects within the bounds of the trigger attached to this object by teleporting it to the opposite side when it leaves
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gameController
{
    public class bounds : MonoBehaviour
    {
        //Coordinates we teleport objects to, set to the corresponding sides of the bounding trigger collider
        public float left = -9.9f;
        public float right = 9.9f;
        public float up = 4.9f;
        public float down = -4.9f;

        //Object's entire collider leaves the trigger, so we determine which side it has exit from and teleport it to the opposite one
        void OnTriggerExit2D(Collider2D other)
        {
            //Debug.Log("Exit bounds");
            //x and y coordinate of the object which has left the trigger
            float x = other.gameObject.transform.position.x;
            float y = other.gameObject.transform.position.y;
            //If it has left [side] we set the object's position to [opposite side], while maintaining the same x or y axis (whichever is NOT the axis it crossed)
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
}

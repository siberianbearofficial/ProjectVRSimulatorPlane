using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyScript : MonoBehaviour
{
    public GameObject AirPlane;

    public bool onCollisionStay = false;
    const float minCollisionSpeed = 0.001f;
    public float collisionSpeed = minCollisionSpeed;
    public float rotationSpeed = 0.05f;
    public float flySpeed = 0.1f;
    const float maxCollisionSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionStay()
    {
        onCollisionStay = true;
    }
    void OnCollisionExit()
    {
        onCollisionStay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("down"))
        {
            if (onCollisionStay)
            {
                AirPlane.transform.Translate(-collisionSpeed, 0, 0);
                if (collisionSpeed <= maxCollisionSpeed)
                {
                    collisionSpeed += minCollisionSpeed;
                }
                else
                {
                    collisionSpeed = minCollisionSpeed;
                }
            }
        }
        if (Input.GetKey("up"))
        {
            if (onCollisionStay)
            {
                AirPlane.transform.Translate(collisionSpeed, 0, 0);
                AirPlane.transform.Rotate(0, 0, collisionSpeed);
                if (collisionSpeed <= maxCollisionSpeed)
                {
                    collisionSpeed += minCollisionSpeed;
                }
                else
                {
                    collisionSpeed = minCollisionSpeed;
                }
            }
            else
            {
                AirPlane.transform.Translate(flySpeed, 0, 0);
                AirPlane.transform.Rotate(0, 0, flySpeed * 0.1f);
            }
        }
        if (Input.GetKey("left"))
        {
            if (onCollisionStay)
            {
                AirPlane.transform.Rotate(0, -rotationSpeed, 0);
            }
            else
            {
                AirPlane.transform.Rotate(rotationSpeed * 0.01f, 0, 0);
            }
        }
        if (Input.GetKey("right"))
        {
            if (onCollisionStay)
            {
                AirPlane.transform.Rotate(0, rotationSpeed, 0);
            }
            else
            {
                AirPlane.transform.Rotate(-rotationSpeed * 0.01f, 0, 0);
            }
        }
        if (collisionSpeed > minCollisionSpeed)
        {
            if (onCollisionStay == true)
            {
                collisionSpeed -= 0.0001f;
            }
        }
        if (collisionSpeed <= minCollisionSpeed)
        {
            collisionSpeed = minCollisionSpeed;
        }
        if (Input.GetKey("space"))
        {
            AirPlane.transform.Translate(0, flySpeed * 0.1f, 0);
            AirPlane.transform.Rotate(0, 0, flySpeed * 0.1f);
        }
        if (!onCollisionStay)
        {
            AirPlane.transform.Rotate(0, 0, flySpeed * (-0.05f));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlaneBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject AirPlane;
    [SerializeField] private float F = 0.05f;
    [SerializeField] private float rotation = 0.1f;
    [SerializeField] private float speed = 0.1f;
    private bool rotationModeCollision = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter()
    {
        rotationModeCollision = false;
    }

    void OnCollisionExit()
    {
        rotationModeCollision = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            AirPlane.transform.Translate(Vector3.up * F);
        }
        if (Input.GetKey("up"))
        {
            AirPlane.transform.Translate(Vector3.right * speed);
        }
        if (Input.GetKey("down"))
        {
            AirPlane.transform.Translate(Vector3.left * speed * (0.1f));
        }
        if (Input.GetKey("left"))
        {
            if (rotationModeCollision)
            {
                AirPlane.transform.Rotate(rotation, 0, 0);
            } else
            {
                AirPlane.transform.Rotate(0, rotation, 0);
            }
        }
        if (Input.GetKey("right"))
        {
            if (rotationModeCollision)
            {
                AirPlane.transform.Rotate(rotation * (-1f), 0, 0);
            } else
            {
                AirPlane.transform.Rotate(0, rotation * (-1f), 0);
            }
        }
        if (AirPlane.transform.rotation.x > 0)
        {
            print(AirPlane.transform.rotation.z);
        }
    }
}

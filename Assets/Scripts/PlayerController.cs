using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed; //unchanging
    public float minSpeed;
    public float acceleration;
    public float pitchSpeed;
    public float yawSpeed;
    public float bankSpeed;
    public float lift;
    public float drag;
    public GameObject Arrow;
    public float rotationCoef; //31f
    public float startArrowPosition; //90f
    public static float speed;
    private float coef = 0.3f;
    public GameObject explosion;
    public GameObject targetExplosion;
    public GameObject airPlane;
    private float gravity;
    private float maximumSpeed;
    public float minFlySpeed;
    public float turnByBank;
    public float realacceleration = 0f;
    private bool cameraSwitch = true;

    [SerializeField] GameObject RUDCircle;

    private void start()
    {
        speed = 0.0f;
        maximumSpeed = maxSpeed;
        gravity = 1.75f;
    }

    private void FixedUpdate()
    {
        //Get data from RUD (We need X axis)
        //start x coordinate: 0.5619224 near 0.56f
        //max x coordinate: near 0.6f
        //delta x: 0.6f - 0.56f = 0.04f
        print(RUDCircle.transform.localPosition.x);
        //realacceleration = (round(RUDCircle.transform.localPosition.x, 5) - 0.56154f) * 200f;
        //print(realacceleration);
        //if (realacceleration <= 0f) realacceleration = 0f;
        // To replicate gravity
        speed -= airPlane.transform.up.y * gravity;
        maximumSpeed -= airPlane.transform.up.y; //can't go as fast going up, can go faster going down
        if (maximumSpeed - maxSpeed < -0.2f * maxSpeed)
        {
            maximumSpeed = 0.8f * maxSpeed;
        }
        else if (maxSpeed - maximumSpeed < -0.2f * maxSpeed)
        {
            maximumSpeed = 1.2f * maxSpeed;
        }
        //speed altering
        if (Input.GetKey("space")) speed += acceleration;
        
        //x to brake
        if (Input.GetKey("x"))
        {
            speed -= (acceleration * coef);
        } else
        {
            speed += realacceleration;
        }
        speed -= drag; //drag force
        if (speed > maximumSpeed)
        {
            speed = maximumSpeed;
        }
        if (speed < minSpeed)
        {
            speed = minSpeed;
        }

        //Position/orientation altering
        //moves forward
        if (speed >= minFlySpeed)
        {
            airPlane.transform.position += airPlane.transform.up * Time.deltaTime * speed * lift;
        }
        airPlane.transform.position += airPlane.transform.forward * Time.deltaTime * speed;

        airPlane.transform.Rotate(-pitchSpeed * Input.GetAxis("Vertical"), 0.0f, 0.0f); //changes pitch of the plane
        float yaw = 0.0f;
        if (Input.GetKey("e"))
        {
            yaw = yawSpeed;
        } else if (Input.GetKey("q"))
        {
            yaw = -yawSpeed;
        }
        airPlane.transform.Rotate(0.0f, 0.0f, yaw); //change yaw of the plane
        airPlane.transform.Rotate(0.0f, -bankSpeed * Input.GetAxis("Horizontal"), 0.0f); //changes bank of the plane
        airPlane.transform.Rotate(0.0f, 0.0f, airPlane.transform.rotation.x * turnByBank);
        //change speedometr information
        Arrow.transform.localRotation = Quaternion.Euler(0, startArrowPosition + (speed / maxSpeed * rotationCoef), 0);
    }

    private float abs(float x)
    {
        if (x >= 0f) return x; return -x;
    }
    private static float round(float number, int scale)
    {
        int pow = 10;
        for (int i = 1; i < scale; i++)
            pow *= 10;
        float tmp = number * pow;
        return (float)(int)((tmp - (int)tmp) >= 0.5f ? tmp + 1 : tmp) / pow;
    }
}

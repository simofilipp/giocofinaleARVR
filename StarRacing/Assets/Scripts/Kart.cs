using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Kart : MonoBehaviour
{
    private Rigidbody rb;
    private float inputX = 0.0f;
    private float inputY = 0.0f;

    public float currentSpeed = 0.0f;
    public float maxSpeed = 20f;
    public float acceleration = 10f;
    public float maxReverseSpeed = 10f;
    public float deceleration = 5;
    public float smoothStop = 5f;
    public float steeringAngle = 25f;
    private float velo;

    Quaternion targetRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetRotation = Quaternion.identity;
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        if (inputY > 0)
        {
            // forward
            if (currentSpeed < maxSpeed)
            {
                currentSpeed += acceleration;
            }
        }
        else if (inputY < 0)
        {
            // backward
            if (currentSpeed > -maxReverseSpeed)
            {
                currentSpeed -= deceleration;
            }
        }
        else
        {
            // Stopping the car when no user input given
            var velocity = rb.velocity;
            var localVel = transform.InverseTransformDirection(velocity);
            currentSpeed = Mathf.SmoothDamp(currentSpeed, 0f, ref velo, Time.deltaTime * smoothStop);
        }

        // Apply currentspeed as rigidbody velocity
        rb.velocity += transform.forward * currentSpeed;
        Debug.Log(currentSpeed + " --- " + rb.velocity);
    }
}

   


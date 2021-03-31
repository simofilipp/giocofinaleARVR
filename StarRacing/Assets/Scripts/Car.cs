using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Rigidbody RB;
    //Wheels Collider
    public WheelCollider frontWheelDXColl, frontWheelSXcoll;
    public WheelCollider backWheelDXColl, backWheelSXcoll;
    //Wheels Transform
    public Transform frontWheelDX, frontWheelSX;
    public Transform backWheelDX, backWheelSX;

    public float steerAngle = 25.0f;
    public float motorForce = 1500f;
    public float steerAngl;
    float h, v;


    // Start is called before the first frame update
    void Start()
    {
          RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Inputs();
        Drive();
        SteerCar();

        UpdateWheelPos(frontWheelDXColl, frontWheelDX);
        UpdateWheelPos(frontWheelSXcoll, frontWheelSX);
        UpdateWheelPos(backWheelDXColl, backWheelDX);
        UpdateWheelPos(backWheelSXcoll, backWheelSX);
    }

    void Inputs()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
       
    }

    void Drive()
    {
        backWheelDXColl.motorTorque = v * motorForce;
        backWheelSXcoll.motorTorque = v * motorForce;
        
    }

    void SteerCar()
    {
        steerAngl = steerAngle * h;
        frontWheelDXColl.steerAngle = steerAngl;
        frontWheelSXcoll.steerAngle = steerAngl;
    }

    void UpdateWheelPos(WheelCollider col, Transform t)
    {
        Vector3 pos = t.position;
        Quaternion rot = t.rotation;

        col.GetWorldPose(out pos, out rot);
        t.position = pos;
        t.rotation = rot;
    }
}

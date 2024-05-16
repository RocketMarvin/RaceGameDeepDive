using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelControllerImprov : MonoBehaviour
{
    public WheelCollider rearLeftCol, rearRightCol;
    public WheelCollider frontLeftCol, frontRightCol;

    public Transform rearLeftWheel, rearRightWheel;
    public Transform frontLeftWheel, frontRightWheel;

    public float acceleration = 100f; 
    public float brakeForce = 300f;
    public float maxTurnAngle = 45f;

    [SerializeField] private float currentSpeed;
    [SerializeField] private float currentAcceleration = 0f;
    [SerializeField] private float currentBrakeForce = 0f;
    [SerializeField] private float currentTurnAngle = 0f;

    public Rigidbody rb;

    [SerializeField] private bool isInReverse = false, isStandingStill = false;

    // Update is called once per frame
    void Update()
    {
        
        currentSpeed = rb.velocity.magnitude * 3.6f;

        Debug.Log(isInReverse);

        if (Input.GetAxis("RTTrigger") > 0 && !isInReverse)
        {
            Debug.Log("test input RTT not in reverse");
            currentAcceleration = acceleration * Input.GetAxis("RTTrigger");
            rearLeftCol.motorTorque = currentAcceleration;
            rearRightCol.motorTorque = currentAcceleration;
            
        }

        if (Input.GetAxis("RTTrigger") > 0 && isInReverse)
        {
            Debug.Log("test input RTT in reverse");
            currentAcceleration = -acceleration * Input.GetAxis("RTTrigger");
            rearLeftCol.motorTorque = currentAcceleration;
            rearRightCol.motorTorque = currentAcceleration;
        }

        if (Input.GetAxis("RTTrigger") == 0) currentAcceleration = 0f;

        if (Input.GetAxis("LTTrigger") != 0)
        {
            currentBrakeForce = brakeForce;
            frontRightCol.brakeTorque = currentBrakeForce;
            frontLeftCol.brakeTorque = currentBrakeForce;
            rearRightCol.brakeTorque = currentBrakeForce;
            rearLeftCol.brakeTorque = currentBrakeForce;
        }

        if (Input.GetAxis("LTTrigger") == 0)
        {
            currentBrakeForce = 0;
            frontRightCol.brakeTorque = 0;
            frontLeftCol.brakeTorque = 0;
            rearRightCol.brakeTorque = 0;
            rearLeftCol.brakeTorque = 0;
        }

        if (Input.GetKey(KeyCode.Joystick1Button1) && !isInReverse) isInReverse = !isInReverse;

        //Debug.Log("currentAccel: " + currentAcceleration);

        currentTurnAngle = maxTurnAngle * Input.GetAxis("LeftOrRight");
        frontLeftCol.steerAngle = currentTurnAngle;
        frontRightCol.steerAngle = currentTurnAngle;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    // Wheel Colliders
    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;
    [SerializeField] private Transform frontLeftTransform, frontRightTransform;
    [SerializeField] private Transform rearLeftTransform, rearRightTransform;

    public float acceleration = 1000f;
    public float backAcceleration = -300f;
    public float brakeForce = 300f;
    public float maxTurnAngle = 45f;

    public Rigidbody rb;

    [SerializeField] private float currentAcceleration = 0f;
    [SerializeField] private float currentBackAcceleration = 0f;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float currentBrakeForce = 0f;
    [SerializeField] private float currentTurnAngle = 0f;

    [SerializeField]private bool isInReverse = false, isStandingStill = false;

    private void Update()
    {
        currentSpeed = rb.velocity.magnitude * 3.6f;

        if (Input.GetAxis("LTTrigger") != 0) currentBrakeForce = brakeForce;
        else currentBrakeForce = 0;

        if (!isInReverse)
        {
            currentAcceleration = acceleration * Input.GetAxis("RTTrigger");
            currentAcceleration = -currentBrakeForce * Input.GetAxis("LTTrigger");
        }
        else
        {
            currentAcceleration = -acceleration * Input.GetAxis("RTTrigger");
            currentAcceleration = currentBrakeForce * Input.GetAxis("LTTrigger");
        }

        if (currentSpeed != 0) isStandingStill = false;
        else
        {
            isStandingStill = true;
            currentAcceleration = 0;
        }

        rearRightWheelCollider.motorTorque = currentAcceleration;
        rearLeftWheelCollider.motorTorque = currentAcceleration;

        Debug.Log("forward: " + currentAcceleration);
        Debug.Log("backward: " + currentAcceleration);
        Debug.Log("brake: " + currentBrakeForce);

        if (Input.GetKey(KeyCode.Space)) currentBrakeForce = brakeForce;
        else currentBrakeForce = 0;

        if (isStandingStill)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                isInReverse = !isInReverse;
                print("isInReverse: " + isInReverse);
            }
        }

        frontRightWheelCollider.brakeTorque = currentBrakeForce;
        frontLeftWheelCollider.brakeTorque = currentBrakeForce;
        rearRightWheelCollider.brakeTorque = currentBrakeForce;
        rearLeftWheelCollider.brakeTorque = currentBrakeForce;

        currentTurnAngle = maxTurnAngle * Input.GetAxis("LeftOrRight");
        frontLeftWheelCollider.steerAngle = currentTurnAngle;
        frontRightWheelCollider.steerAngle = currentTurnAngle;

        UpdateWheel(frontLeftWheelCollider, frontLeftTransform);
        UpdateWheel(frontRightWheelCollider, frontRightTransform);
        UpdateWheel(rearLeftWheelCollider, rearLeftTransform);
        UpdateWheel(rearRightWheelCollider, rearRightTransform);
         

    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 posistion;
        Quaternion rotation;
        col.GetWorldPose(out posistion, out rotation);

        trans.position = posistion;
        trans.rotation = rotation;
    }
}

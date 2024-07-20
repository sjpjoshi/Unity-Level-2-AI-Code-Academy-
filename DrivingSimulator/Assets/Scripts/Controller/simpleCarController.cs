using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleCarController : MonoBehaviour {

    // steering variables
    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;

    // Colliders
    [Header("Wheel Variables")]
    public WheelCollider frontDriverWheel;
    public WheelCollider frontPassgenerWheel;
    public WheelCollider backDriverWheel;
    public WheelCollider backPassgenerWheel;

    // Transforms
    [Header("Transform Variables")]
    public Transform frontDriverTransform;
    public Transform frontPassagenerTransform;
    public Transform backDriverTransform;
    public Transform backPassagenerTransform;

    //Vectors
    [Header("Vector Variable")]
    public Vector3 CenterOfMass;

    // Steering variables
    [Header("Vector Variable")]
    public float maxSteerAngle = 30;
    public float motorForce = 50;

    void Awake() {
        // get our center of mass in the beginning, we dont want our car to flip over on the start of the game
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.centerOfMass = CenterOfMass; 

    } // Awake

    void FixedUpdate() {
        getInput();
        Steer();
        Accelerate();
        updateWheelPositions();

    } // Update

    public void getInput() {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical");

    } // getInput

    private void Steer() {
        // get our steering angle
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        // assigning to both wheels
        frontDriverWheel.steerAngle = m_steeringAngle;
        frontPassgenerWheel.steerAngle = m_steeringAngle;


    } // Steer

    private void Accelerate() {
        float BrakeForce = 0f;

        frontDriverWheel.motorTorque = m_verticalInput * motorForce;
        frontPassgenerWheel.motorTorque = m_verticalInput * motorForce;

        if (Input.GetKey(KeyCode.Space)) {
            BrakeForce = 1000;

        } // if

        frontDriverWheel.brakeTorque = BrakeForce;
        frontPassgenerWheel.brakeTorque = BrakeForce;
        backDriverWheel.brakeTorque = BrakeForce;
        backPassgenerWheel.brakeTorque = BrakeForce;

    } // Accelerate

    private void updateWheelPositions() {
        updateWheelPose(frontDriverWheel, frontDriverTransform);
        updateWheelPose(frontPassgenerWheel, frontPassagenerTransform);
        updateWheelPose(backDriverWheel, backDriverTransform);
        updateWheelPose(backPassgenerWheel, backPassagenerTransform);

    } // updateWheelPositions

    public void updateWheelPose(WheelCollider collider, Transform transform) { 
        Vector3 position = transform.position; // storing our position
        
        // A quaternion is a rotation variable
        // another name for it is called 6DOF, the 6 degrees of freedom
        // this will allow use to change our rotatin 

        Quaternion quat = transform.rotation; // storing our rotation

        // the out keyword in C# means a pass by reference value
        // it will directly get the memory addresses of these values and pass them to the premade function
        collider.GetWorldPose(out position, out quat);

        transform.position = position;
        transform.rotation = quat;

    } // updateWheelPose


} // simpleCarController

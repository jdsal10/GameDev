using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    // Input axis names
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    // Input values
    private float horizontalInput;
    private float verticalInput;

    // Steering and braking variables
    private float actualSteeringAngle;
    private float currentBreakingForce;
    private bool breaking;

    // Motor-related parameters
    public float motorForce;
    public float breakingForce;
    public float maximumSteeringAngle;

    // Wheel colliders for each wheel
    public WheelCollider flWheelCollider;
    public WheelCollider frWheelCollider;
    public WheelCollider blWheelCollider;
    public WheelCollider brWheelCollider;

    // Wheel transforms for visual representation
    public Transform flWheelTransform;
    public Transform frWheelTransform;
    public Transform blWheelTransform;
    public Transform brWheelTransform;

    public AudioClip carMovingAudio;  // Audio clip for car movement sound

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to handle player input
    public void HandleInput()
    {
        GetInputOfPlayer();
        Motor();
        Steering();
        WheelsChange();
    }

    // Method to control the motor (acceleration and braking)
    public void Motor()
    {
        // Apply motor torque to the front wheels based on the vertical input
        flWheelCollider.motorTorque = verticalInput * motorForce;
        frWheelCollider.motorTorque = verticalInput * motorForce;

        // Determine braking force based on the 'breaking' boolean
        currentBreakingForce = breaking ? breakingForce : 0f;

        // Apply brakes to all wheels
        ApplyingBrekes();

        // Play car movement audio if available
        if (carMovingAudio != null)
        {
            AudioSource.PlayClipAtPoint(carMovingAudio, transform.position);
        }
    }

    // Method to apply brakes to all wheels
    public void ApplyingBrekes()
    {
        frWheelCollider.brakeTorque = currentBreakingForce;
        flWheelCollider.brakeTorque = currentBreakingForce;
        brWheelCollider.brakeTorque = currentBreakingForce;
        blWheelCollider.brakeTorque = currentBreakingForce;
    }

    // Method to control steering
    public void Steering()
    {
        // Calculate the actual steering angle based on the horizontal input
        actualSteeringAngle = maximumSteeringAngle * horizontalInput;

        // Apply steering angle to the front wheel colliders
        flWheelCollider.steerAngle = actualSteeringAngle;
        frWheelCollider.steerAngle = actualSteeringAngle;
    }

    // Method to get player input values
    public void GetInputOfPlayer()
    {
        horizontalInput = Input.GetAxis(Horizontal);
        verticalInput = Input.GetAxis(Vertical);
        breaking = Input.GetKey(KeyCode.Space);
    }

    // Method to update the visual representation of the wheels
    public void WheelsChange()
    {
        UpdateWheel(flWheelCollider, flWheelTransform);
        UpdateWheel(frWheelCollider, frWheelTransform);
        UpdateWheel(blWheelCollider, blWheelTransform);
        UpdateWheel(brWheelCollider, brWheelTransform);
    }

    // Method to update the position and rotation of a wheel's visual representation
    public void UpdateWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;

        // Get the world position and rotation of the wheel collider
        wheelCollider.GetWorldPose(out pos, out rot);

        // Update the visual representation's position and rotation
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float actualSteeringAngle;
    private float currentBreakingForce;
    private bool breaking;

    public float motorForce;
    public float breakingForce;
    public float maximumSteeringAngle;

    public WheelCollider flWheelCollider;
    public WheelCollider frWheelCollider;
    public WheelCollider blWheelCollider;
    public WheelCollider brWheelCollider;

    public Transform flWheelTransform;
    public Transform frWheelTransform;
    public Transform blWheelTransform;
    public Transform brWheelTransform;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HandleInput()
    {
        GetInputOfPlayer();
        Motor();
        Steering();
        WheelsChange();
    }

    public void Motor()
    {
        flWheelCollider.motorTorque = verticalInput * motorForce;
        frWheelCollider.motorTorque = verticalInput * motorForce;
        currentBreakingForce = breaking ? breakingForce : 0f;
        ApplyingBrekes();

    }

    public void ApplyingBrekes()
    {
        frWheelCollider.brakeTorque = currentBreakingForce;
        flWheelCollider.brakeTorque = currentBreakingForce;
        brWheelCollider.brakeTorque = currentBreakingForce;
        blWheelCollider.brakeTorque = currentBreakingForce;

    }

    public void Steering()
    {
        actualSteeringAngle = maximumSteeringAngle * horizontalInput;
        flWheelCollider.steerAngle = actualSteeringAngle;
        frWheelCollider.steerAngle = actualSteeringAngle;
    }

    public void GetInputOfPlayer()
    {
        horizontalInput = Input.GetAxis(Horizontal);
        verticalInput = Input.GetAxis(Vertical);
        breaking = Input.GetKey(KeyCode.Space);
    }

    public void WheelsChange()
    {
        UpdateWheel(flWheelCollider, flWheelTransform);
        UpdateWheel(frWheelCollider, frWheelTransform);
        UpdateWheel(blWheelCollider, blWheelTransform);
        UpdateWheel(brWheelCollider, brWheelTransform);
    }

    public void UpdateWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInteraction : MonoBehaviour
{
    public Camera carCamera;
    public Camera personCamera;
    public carController carController; // Reference to the carController script
    public GameObject playerObject; // Reference to the player GameObject

    private bool isPlayerInCar;
    private Transform player;

    void Start()
    {
        // Initialize cameras
        carCamera.gameObject.SetActive(false); // Deactivate car camera initially
        personCamera.gameObject.SetActive(true); // Activate person camera initially

        // Set the player reference using the assigned GameObject or another method
        player = playerObject.transform;
    }

    void Update()
    {
        // Check for key inputs
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleCarInteraction(); // Toggle between entering and exiting the car
        }

        if (Input.GetKeyDown(KeyCode.X) && isPlayerInCar)
        {
            SwitchCamera(); // Switch between car and person cameras
        }

        // Forward input to carController only when the player is in the car
        if (isPlayerInCar)
        {
            carController.HandleInput(); // Forward input to the carController script
        }
    }

    void ToggleCarInteraction()
    {
        if (isPlayerInCar)
            ExitCar(); // If the player is in the car, exit it
        else
            EnterCar(); // If the player is outside the car, enter it
    }

    void EnterCar()
    {
        SetupCarInteraction(true); // Set up car interaction when entering
    }

    void ExitCar()
    {
        SetupCarInteraction(false); // Set up car interaction when exiting
    }

    void SetupCarInteraction(bool enterCar)
    {
        player.parent = enterCar ? transform : null; // Set player's parent to the car or none
        player.position = enterCar ? transform.position : transform.position + Vector3.up; // Adjust player's position
        isPlayerInCar = enterCar; // Update the player's state

        personCamera.gameObject.SetActive(!isPlayerInCar); // Activate or deactivate person camera
        carCamera.gameObject.SetActive(isPlayerInCar); // Activate or deactivate car camera
    }

    void SwitchCamera()
    {
        carCamera.gameObject.SetActive(!carCamera.gameObject.activeSelf); // Switch car camera state
        personCamera.gameObject.SetActive(!personCamera.gameObject.activeSelf); // Switch person camera state
    }
}

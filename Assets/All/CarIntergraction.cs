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
        carCamera.gameObject.SetActive(false);
        personCamera.gameObject.SetActive(true);

        // Set the player reference using the assigned GameObject or another method
        player = playerObject.transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleCarInteraction();
        }

        if (Input.GetKeyDown(KeyCode.X) && isPlayerInCar)
        {
            SwitchCamera();
        }

        // Forward input to carController only when the player is in the car
        if (isPlayerInCar)
        {
            carController.HandleInput();
        }
    }

    void ToggleCarInteraction()
    {
        if (isPlayerInCar) ExitCar();
        else EnterCar();
    }

    void EnterCar()
    {
        SetupCarInteraction(true);
    }

    void ExitCar()
    {
        SetupCarInteraction(false);
    }

    void SetupCarInteraction(bool enterCar)
    {
        player.parent = enterCar ? transform : null;
        player.position = enterCar ? transform.position : transform.position + Vector3.up;
        isPlayerInCar = enterCar;

        personCamera.gameObject.SetActive(!isPlayerInCar);
        carCamera.gameObject.SetActive(isPlayerInCar);
    }

    void SwitchCamera()
    {
        carCamera.gameObject.SetActive(!carCamera.gameObject.activeSelf);
        personCamera.gameObject.SetActive(!personCamera.gameObject.activeSelf);
    }
}

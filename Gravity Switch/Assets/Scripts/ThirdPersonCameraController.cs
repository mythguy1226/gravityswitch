using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    // Fields needed for transforming the camera
    public float rotationSpeed = 1;
    public Transform target;
    public Transform player;
    float mouseX;
    float mouseY;

    // Awake Method runs as the program begins
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update Method 
    void Update()
    {
        CameraControl();
    }

    // Method that controls Camera Movement and Rotation
    void CameraControl()
    {
        // Get the Inputs and clamp the Y value to only go a certain range
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        // Update the Camera to look at the target
        transform.LookAt(target);

        // Update the rotations of both the camera target and the player as the mouse moves
        target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}

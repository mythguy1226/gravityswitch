using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    // Fields needed for player functionality
    public float speed = 20.0f;
    Rigidbody playerBody;
    public float jumpSpeed = 40.0f;
    public static bool canJump;

    // Init
    private void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        canJump = true;
    }
    // Update Method
    void Update()
    {
        // Call Player Updates
        PlayerMovement();
    }

    // Method that Updates Player position based on input
    void PlayerMovement()
    {
        // Get the Input for moving the character
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        // Store user input as a movement vector and then move the player
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        playerBody.MovePosition(transform.position + transform.TransformDirection(m_Input) * Time.deltaTime * speed);

        // Implementation for Jumping
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            // Condition for which direction to jump
            if(Gravity_Switch.normalGravity) // Jump Up
            {
                playerBody.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
            }
            else // Jump Down
            {
                playerBody.AddForce(new Vector3(0, -jumpSpeed, 0), ForceMode.Impulse);
            }
            canJump = false;
        }
    }

    // Method for Collision Resolution
    private void OnCollisionEnter(Collision collision)
    {
        // Platform collisions
        if (collision.gameObject.name.Contains("Platform"))
        {
            // Reset capability to jump
            canJump = true;
        }
    }
}

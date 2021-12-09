using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    // Fields needed for player functionality
    public float speed = 10.0f;
    Rigidbody playerBody;
    public float jumpSpeed = 40.0f;
    public static bool canJump;
    Animator animator;

    // Init
    private void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        canJump = true;
        animator = transform.GetChild(1).gameObject.GetComponent<Animator>();
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
        playerBody.MovePosition(transform.position + Vector3.Normalize(transform.TransformDirection(m_Input)) * Time.deltaTime * speed);

        if ((m_Input.x != 0 || m_Input.z > 0) && canJump) animator.SetBool("IsRunning", true);
        else animator.SetBool("IsRunning", false);

        //Debug.Log(m_Input.x !)

        // Implementation for Jumping
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            animator.SetTrigger("Jump");
            // Condition for which direction to jump
            if (Gravity_Switch.normalGravity) // Jump Up
            {
                playerBody.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
            }
            else // Jump Down
            {
                playerBody.AddForce(new Vector3(0, -jumpSpeed, 0), ForceMode.Impulse);
            }
            canJump = false;
        }

        // Allows Player to Quit Game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (!canJump) animator.SetBool("IsFalling", true);
        else animator.SetBool("IsFalling", false);
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

    void OnGUI()
    {
        // Declare Text Style and Button Style
        GUIStyle style = new GUIStyle();

        // Set Style Rules
        style.fontSize = 60;
        style.normal.textColor = Color.yellow;

        // Place the Gravity Status
        if(Gravity_Switch.normalGravity) // Downwards
        {
            GUI.Label(new Rect(25, 20, 200, 150), "Gravity: Down", style);
        }
        else // Upwards
        {
            GUI.Label(new Rect(25, 20, 200, 150), "Gravity: Up", style);
        }
    }
}

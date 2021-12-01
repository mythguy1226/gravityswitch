using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Init fields
    public GameObject player;
    public bool normalGravity = Gravity_Switch.normalGravity;

    // Update is called once per frame
    void Update()
    {
        // Check if player is in a death state
        CheckDeath();
    }

    // Method that checks for death state
    void CheckDeath()
    {
        // Level Bounds
        if (player.transform.position.y >= 50.0f || player.transform.position.y <= -50.0f)
        {
            // Kill Player if Reached
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            if (!normalGravity) // Reset Gravity
            {
                Physics.gravity = new Vector3(0, -9.8F, 0);
                normalGravity = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int level;

    // Method for Collision Resolution
    private void OnCollisionEnter(Collision collision)
    {
        // Player Collisions
        if (collision.gameObject.name.Contains("Player"))
        {
            // Go to specified level
            SceneManager.LoadScene(level);
        }
    }
}

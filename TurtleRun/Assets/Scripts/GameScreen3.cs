using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScreen3 : MonoBehaviour
{
    // This method is called when another collider enters the trigger collider attached to the object this script is attached to.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object has a Rigidbody2D component (to ensure it's the player)
        if (collision.attachedRigidbody != null)
        {
            // Change the scene to "GameScreen3"
            SceneManager.LoadScene("GameScreen3");
        }
    }
}

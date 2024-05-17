using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeOnCollision : MonoBehaviour
{
    // This method is called when another collider enters the trigger collider attached to the object this script is attached to.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object has a Rigidbody2D component (to ensure it's the player or the desired object)
        if (collision.attachedRigidbody != null)
        {
            // Change the scene to "GameScreen2"
            SceneManager.LoadScene("GameScreen2");
        }
    }
}

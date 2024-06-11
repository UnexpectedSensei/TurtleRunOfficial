using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image[] hearts; // Array to hold the heart images
    private string currentState = "idle"; // Example of default state

    void Start()
    {
        UpdateHeartsUI(); // Update the UI to show the correct number of hearts
    }

    // Method to handle taking damage
    public void TakeDamage(int damage)
    {
        GameManager.instance.TakeDamage(damage); // Reduce the player's lives by the damage amount
        Debug.Log("Player took damage. Current lives: " + GameManager.instance.currentLives);
        UpdateHeartsUI(); // Update the UI to reflect the new number of lives

        if (GameManager.instance.currentLives <= 0)
        {
            Die(); // Handle player death if lives reach zero
        }
    }

    // Method to change the player's state
    public void ChangeState(string newState)
    {
        currentState = newState;
    }

    // Method to get the current state of the player
    public string GetCurrentState()
    {
        return currentState;
    }

    // Method triggered when the player collides with another object
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player collided with: " + other.gameObject.name);
        // Check if the object the player collided with has the tag "CrabEnemy"
        if (other.CompareTag("CrabEnemy"))
        {
            Debug.Log("Collided with CrabEnemy");
            // If the player is in "idle", "walking", or "sprinting" state, take damage
            if (currentState == "idle" || currentState == "walking" || currentState == "sprinting")
            {
                TakeDamage(1);
            }
        }
    }

    // Method to handle player death
    void Die()
    {
        Debug.Log("Player died");
        // Load the DeathScreen scene upon death
        SceneManager.LoadScene("DeathScreen");
    }

    // Method to update the hearts UI based on the current lives
    void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Show or hide heart based on current lives
            hearts[i].enabled = i < GameManager.instance.currentLives;
        }
    }

    // Method to handle healing the player
    public void Heal(int amount)
    {
        GameManager.instance.Heal(amount); // Increase the player's lives by the heal amount
        UpdateHeartsUI(); // Update the UI to reflect the new number of lives
    }
}

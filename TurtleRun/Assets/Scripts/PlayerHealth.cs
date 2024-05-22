using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3; // Maximum number of lives
    private int currentLives; // Current number of lives
    private string currentState = "idle"; // Example of default state
    public Image[] hearts; // Array to hold the heart images
    public bool isInvulnerable = false; // Track invulnerability state
    private float invulnerabilityEndTime = 10f; // Time when invulnerability ends
    void Start()
    {
        // Initialize the player's lives
        currentLives = maxLives;
        UpdateHeartsUI();
    }




    // Method to handle taking damage
    public void TakeDamage(int damage)
    {
        currentLives -= damage;
        if (currentLives < 0)
        {
            currentLives = 0;
        }
        UpdateHeartsUI();

        if (currentLives <= 0)
        {
            Die();
        }
    }

    private void Update()
    {
        //Check if invulnerability time has passed
        if (isInvulnerable && Time.time > invulnerabilityEndTime)
        {
            isInvulnerable = false;
        }
    }

    public void StartInvulnerability(float duration)
    {
        isInvulnerable = true;
        invulnerabilityEndTime = Time.time + duration;
    }

    // Update or other methods to change the state
    public void ChangeState(string newState)
    {
        currentState = newState;
    }

    public string GetCurrentState()
    {
        return currentState;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CrabEnemy"))
        {
            if (currentState == "idle" || currentState == "walking")
            {
                TakeDamage(1);
            }
        }
    }

    void Die() // Method to handle player death and change to DeathScreen
    {
        SceneManager.LoadScene("DeathScreen");
    }

    // Method to update the hearts UI
    void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentLives)
            {
                hearts[i].enabled = true; // Show heart
            }
            else
            {
                hearts[i].enabled = false; // Hide heart
            }
        }
    }

    // Method to handle healing (if applicable)
    public void Heal(int amount)
    {
        currentLives += amount;
        if (currentLives > maxLives)
        {
            currentLives = maxLives;
        }
        UpdateHeartsUI();
    }


}

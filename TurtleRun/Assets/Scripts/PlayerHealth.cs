using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3; // Maximum number of lives
    private int currentLives; // Current number of lives

    public Image[] hearts; // Array to hold the heart images

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

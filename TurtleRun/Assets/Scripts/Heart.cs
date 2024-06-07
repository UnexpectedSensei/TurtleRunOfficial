using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public int healAmount = 1; // Amount of health to heal the player

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object colliding with this healing object is the player
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            // Heal the player
            playerHealth.Heal(healAmount);

            // Destroy the healing object after it's used
            Destroy(gameObject);
        }
    }
}

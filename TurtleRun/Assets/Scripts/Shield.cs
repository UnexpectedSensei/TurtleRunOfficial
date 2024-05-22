using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float invulnerabilityDuration = 10f; // Duration of invulnerability in seconds

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the player's script component that handles invulnerability
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Make the player invulnerable
                playerHealth.StartInvulnerability(invulnerabilityDuration);
            }

            // Destroy the invulnerability object
            Destroy(gameObject);
        }
    }
}

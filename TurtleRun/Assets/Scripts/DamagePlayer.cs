using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int Damage = 1; // Damage caused to player

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enemy collided with: " + collision.gameObject.name);
        PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>(); // Get the PlayerHealth component from the collided object
        if (health != null)
        {
            Debug.Log("Damaging player");
            health.TakeDamage(Damage); // Apply damage to the player
            
        }
    }
}


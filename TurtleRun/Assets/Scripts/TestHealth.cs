using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHealth : MonoBehaviour
{
    public PlayerHealth Health;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Example: Press Space to take damage
        {
            Health.TakeDamage(1);
        }

        if (Input.GetKeyDown(KeyCode.H)) // Example: Press H to heal
        {
            Health.Heal(1);
        }
    }
}

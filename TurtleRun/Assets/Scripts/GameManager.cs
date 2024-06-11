using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int maxLives = 3; // Maximum number of lives
    public int currentLives; // Current number of lives

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist this object across scenes
            currentLives = maxLives; // Initialize current lives
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to reduce lives
    public void TakeDamage(int damage)
    {
        currentLives -= damage;
        if (currentLives < 0)
        {
            currentLives = 0;
        }
    }

    // Method to heal lives
    public void Heal(int amount)
    {
        currentLives += amount;
        if (currentLives > maxLives)
        {
            currentLives = maxLives;
        }
    }
}

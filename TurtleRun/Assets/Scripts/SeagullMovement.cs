using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullMovement : MonoBehaviour
{
    public float speed = 5f; // Speed at which the character moves
    public GameObject item1; // First item prefab
    public GameObject item2; // Second item prefab
    public float minDropInterval = 15f; // Minimum interval between drops
    public float maxDropInterval = 25f; // Maximum interval between drops

    private float screenWidth;

    void Start()
    {
        // Calculate screen width in world units
        screenWidth = Camera.main.aspect * Camera.main.orthographicSize * 2f;

        // Start the coroutine to drop items
        StartCoroutine(DropItemsAtRandomIntervals());
    }

    void Update()
    {
        // Move the character across the screen
        transform.position += Vector3.right * speed * Time.deltaTime;

        // Wrap the character to the left side of the screen when it goes off the right edge
        if (transform.position.x > screenWidth / 2)
        {
            transform.position = new Vector3(-screenWidth / 2, transform.position.y, transform.position.z);
        }
    }

    IEnumerator DropItemsAtRandomIntervals()
    {
        while (true)
        {
            // Wait for a random interval before dropping the next item
            float waitTime = Random.Range(minDropInterval, maxDropInterval);
            yield return new WaitForSeconds(waitTime);

            // Choose a random item to drop
            GameObject itemToDrop = Random.value > 0.5f ? item1 : item2;

            // Instantiate the item at the character's current position
            Instantiate(itemToDrop, transform.position, Quaternion.identity);
        }
    }
}

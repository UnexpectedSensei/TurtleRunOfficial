using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullMovement : MonoBehaviour
{
    public float speed = 10f; // Speed of the character
    public GameObject item1; // First item prefab
    public GameObject item2; // Second item prefab
    public float minDropInterval = 5f; // Minimum interval between drops
    public float maxDropInterval = 15f; // Maximum interval between drops

    private RectTransform rectTransform;
    private Canvas canvas;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        // Start the coroutine to drop items
        StartCoroutine(DropItemsAtRandomIntervals());
    }

    void Update()
    {
        // Move the character horizontally
        rectTransform.anchoredPosition += Vector2.right * speed * Time.deltaTime;

        // Wrap the character to the left side of the screen when it goes off the right edge
        if (rectTransform.anchoredPosition.x > canvas.pixelRect.width)
        {
            rectTransform.anchoredPosition = new Vector2(-rectTransform.rect.width, rectTransform.anchoredPosition.y);
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
            GameObject itemInstance = Instantiate(itemToDrop, transform.parent);
            itemInstance.GetComponent<RectTransform>().anchoredPosition = rectTransform.anchoredPosition;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullMovement : MonoBehaviour
{
    public float speed = 10f; // Speed of the character

    private RectTransform rectTransform;
    private Canvas canvas;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
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
}

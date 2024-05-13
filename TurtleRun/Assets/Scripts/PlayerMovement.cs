using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        public float Speed = 5f; // Speed of the player
        private Animator animator; // Reference to the Animator component
        private Rigidbody2D rb; // Reference to the Rigidbody2D component

        void Start()
        {
            // Get the Animator and Rigidbody2D components attached to the GameObject
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            float moveX = 0f;
            float moveY = 0f;

            // Check for arrow key inputs
            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveY = 1f;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                moveY = -1f;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveX = -1f;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                moveX = 1f;
            }

            // Create a movement vector and normalize it to ensure consistent speed
            Vector2 movement = new Vector2(moveX, moveY).normalized;

            // Set the velocity of the Rigidbody2D
            rb.velocity = movement * Speed;

            
        }
    }
}
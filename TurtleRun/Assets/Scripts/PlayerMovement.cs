using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        public float Speed = 5f; // Speed of the player
        public float Sprint = 10f; //Speed of the player sprinting
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
            // Check for DownMovement key being held
            if (Input.GetButton("DownMovement"))
            {
                animator.Play("Hiding");
                rb.velocity = Vector2.zero; // Stop all movement when hiding
            }
            else
            {
                HandleOtherInputs(); // Check for other inputs only if the DownMovement button is not being held
            }
        }

        void HandleOtherInputs()
        {
            float moveX = 0f;
            float moveY = 0f;

            if (Input.GetButton("LeftMovement")) // Moves the player character left
            {
                animator.Play("Walking"); // Play walking animation sequence
                moveX = -1f; // Adjust the value if needed
            }
            else if (Input.GetButton("RightMovement")) // Moves the player character right
            {
                animator.Play("Walking");
                moveX = 1f; // Adjust the value if needed
            }
            else if (Input.GetButton("Sprint"))
            {
                animator.Play("Sprint");
                moveX = Sprint;
            }
            else
            {
                // If no movement keys are pressed, play the idle animation
                animator.Play("Idle");
            }

            // Create a movement vector and normalize it to ensure consistent speed
            Vector2 movement = new Vector2(moveX, moveY).normalized;

            // Set the velocity of the player's Rigidbody
            rb.velocity = movement * Speed;
        }
    }
}
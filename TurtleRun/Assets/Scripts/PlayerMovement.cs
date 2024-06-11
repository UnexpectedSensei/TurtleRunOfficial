using UnityEngine;

namespace Assets.Scripts
{
        public class PlayerMovement : MonoBehaviour
        {
            public float Speed = 5f; // Speed of the player
            public float SprintSpeed = 10f; // Speed of the player sprinting
            private Animator animator; // Reference to the Animator component
            private Rigidbody2D rb; // Reference to the Rigidbody2D component
            private BoxCollider2D boxCollider; // Reference to the BoxCollider2D component
            public float MaxSprint = 10; // Max total of sprint bar
            public SprintBar SprintBar;

            void Start()
            {
                // Get the Animator, Rigidbody2D, and BoxCollider2D components attached to the GameObject
                animator = GetComponent<Animator>();
                rb = GetComponent<Rigidbody2D>();
                boxCollider = GetComponent<BoxCollider2D>();
                SprintBar.SetMaxSprint(MaxSprint);
            }

            void Update()
            {
                // Check for DownMovement key being held
                if (Input.GetButton("DownMovement"))
                {
                    animator.Play("Hiding");
                    rb.velocity = Vector2.zero; // Stop all movement when hiding
                    boxCollider.enabled = false; // Disable the box collider when hiding
                }
                else
                {
                    HandleOtherInputs(); // Check for other inputs only if the DownMovement button is not being held
                    boxCollider.enabled = true; // Enable the box collider when not hiding
                }
            }

            void HandleOtherInputs()
            {
                float moveX = 0f;
                float moveY = 0f;
                bool isSprinting = false;

                // Check for sprinting first
                if (Input.GetKey(KeyCode.Keypad5) && SprintBar.GetCurrentSprint() > 0)
                {
                    animator.Play("Sprinting");
                    moveX = Input.GetButton("RightMovement") ? 1f : 0f; // Only sprint to the right
                    isSprinting = true;
                    SprintBar.SetSprint(SprintBar.GetCurrentSprint() - Time.deltaTime); // Decrease sprint value over time
                }

                if (!isSprinting)
                {
                    // Check for other movements if not sprinting
                    if (Input.GetButton("LeftMovement"))
                    {
                        animator.Play("Walking"); // Play walking animation sequence
                        moveX = -1f; // Adjust the value if needed
                    }
                    else if (Input.GetButton("RightMovement"))
                    {
                        animator.Play("Walking");
                        moveX = 1f; // Adjust the value if needed
                    }

                    // If no movement keys are pressed, play the idle animation
                    if (moveX == 0 && moveY == 0)
                    {
                        animator.Play("Idle");
                    }
                }

                // Create a movement vector and normalize it to ensure consistent speed
                Vector2 movement = new Vector2(moveX, moveY).normalized;

                // Set the velocity of the player's Rigidbody, adjusting speed for sprinting
                rb.velocity = movement * (isSprinting ? SprintSpeed : Speed);
            }
        }
    }

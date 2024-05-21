using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    public GameObject PointA; // Reference to PointA GameObject
    public GameObject PointB; // Reference to PointB GameObject
    private Rigidbody2D rb; // Reference to the Rigidbody2D component on the character
    public float speed; // Speed at which the character moves

    private Vector2 targetVelocity; // The current velocity towards the target point

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D component attached to this GameObject
        rb = GetComponent<Rigidbody2D>();

        // Initially set the target velocity towards PointB
        targetVelocity = CalculateVelocity(PointB.transform.position);
        rb.velocity = targetVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        // Constantly apply the target velocity to maintain movement
        rb.velocity = targetVelocity;
    }

    // This method is called when the collider attached to this GameObject enters a collision with another collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with PointA or PointB
        if (collision.gameObject == PointA || collision.gameObject == PointB)
        {
            // Reverse the direction of movement by recalculating the velocity
            targetVelocity = -rb.velocity;
        }
    }

    // Calculate the velocity towards a target point based on a fixed speed
    private Vector2 CalculateVelocity(Vector3 targetPosition)
    {
        Vector2 direction = (targetPosition - transform.position);
        direction.Normalize(); // Normalize to get direction only
        return direction * speed; // Set velocity based on direction and fixed speed
    }
}

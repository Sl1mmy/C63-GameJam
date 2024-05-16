using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Bouncy : MonoBehaviour
{
    public float bounceForce = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with the player
        if (collision.CompareTag("Player"))
        {
            print("isPlayer");
            // Get the Rigidbody component attached to the player
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();

            // Check if a Rigidbody component is attached to the player
            if (playerRb != null)
            {
                // Get the direction opposite to the object's current velocity
                Vector3 bounceDirection = (collision.transform.position - transform.position).normalized;
                print(bounceDirection);
                // Apply a force to the player in the opposite direction to create a bouncing effect
                playerRb.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse);
            }
            else
            {
                Debug.LogWarning("Player object requires a Rigidbody component for bouncing.");
            }
        }
    }
}


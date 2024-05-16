using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    // Reference to the coin counter
    public CoinCounter coinCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collides with the coin
        if (collision.CompareTag("Player"))
        {
            // Increment the coin counter
            coinCounter.IncrementCoinCount();

            // Destroy the coin object
            Destroy(gameObject);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTimer : MonoBehaviour
{
    public StartTimer stopwatchController; // Reference to the TriggerAndStopwatch script controlling the stopwatch

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the stop trigger is activated by the specified GameObject
        if (collision.CompareTag("Player")) // Adjust "Player" tag based on your GameObject's tag
        {
            // Stop the stopwatch
            stopwatchController.StopStopwatch();
        }
    }
}

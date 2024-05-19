using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartTimer : MonoBehaviour
{
    public Canvas uiCanvas; // Reference to the UI Canvas you want to activate
    public TextMeshProUGUI stopwatchText; // Reference to the Text element where you want to display the stopwatch

    public float elapsedTime = 0f; // Elapsed time for the stopwatch
    private bool stopwatchRunning = false; // Flag to track if the stopwatch is running

    private void Start()
    {
        // Deactivate the UI canvas at the start
        if (uiCanvas != null)
        {
            uiCanvas.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the trigger is activated by the specified GameObject
        if (collision.CompareTag("Player")) // Adjust "Player" tag based on your GameObject's tag
        {
            // Activate the UI canvas
            if (uiCanvas != null)
            {
                uiCanvas.gameObject.SetActive(true);
            }

            StartStopwatch();
        }
    }

    private void Update()
    {
        // Update the stopwatch if it's running
        if (stopwatchRunning)
        {
            elapsedTime += Time.deltaTime;

            // Update the stopwatch text
            if (stopwatchText != null)
            {
                stopwatchText.text = FormatTime(elapsedTime);
            }
        }
    }

    private void StartStopwatch()
    {
        elapsedTime = 0f;
        stopwatchRunning = true;
    }

    public void StopStopwatch()
    {
        stopwatchRunning = false;
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        float milliseconds = (time * 1000) % 1000;
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}

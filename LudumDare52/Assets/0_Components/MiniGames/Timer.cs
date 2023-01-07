using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    private float timeRemaining;
    private bool timerRunning;

    // Start the timer
    public void StartTimer(float time)
    {
        timeRemaining = time;
        timerRunning = true;
    }

    // Stop the timer
    public void StopTimer()
    {
        timerRunning = false;
    }

    // Check if the timer has run out
    public bool IsTimeUp()
    {
        return timeRemaining <= 0;
    }

    // Update the timer display
    private void Update()
    {
        if (timerRunning)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = timeRemaining.ToString("F2");
        }
    }
}

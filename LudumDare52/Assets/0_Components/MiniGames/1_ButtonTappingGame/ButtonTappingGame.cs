using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTappingGame : MonoBehaviour
{
    public Button button;
    public int tapCount;
    public float timeLimit;
    public Timer timer;

    private bool gameStarted;
    private bool gameOver;
    private int currentTaps;

    // Start the game
    public void StartGame()
    {
        gameStarted = true;
        gameOver = false;
        currentTaps = 0;
        timer.StartTimer(timeLimit);
    }

    // Stop the game
    public void StopGame()
    {
        gameStarted = false;
        timer.StopTimer();
        this.gameObject.SetActive(false);
    }

    // Check if the game is over
    public bool IsComplete()
    {
        return gameOver;
    }

    // Update the game state
    private void Update()
    {
        if (gameStarted && !gameOver)
        {
            // Check if the player has reached the tap count
            if (currentTaps >= tapCount)
            {
                gameOver = true;
                StopGame();
            }

            // Check if the timer has run out
            if (timer.IsTimeUp())
            {
                gameOver = true;
                StopGame();
            }
        }
    }

    // Handle button taps
    public void OnButtonTap()
    {
        currentTaps++;
    }
}

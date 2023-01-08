using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TappingGame : MonoBehaviour
{
    public int tapCount;
    public float timeLimit;
    public Timer timer;

    private bool gameStarted;
    private bool gameOver;
    private int currentTaps;

    [SerializeField] GameObject dataBeingHarvested;
    [SerializeField] GameObject failedImage;

    // Start the game
    public void StartGame()
    {
        gameStarted = true;
        gameOver = false;
        currentTaps = 0;
        timer.StartTimer(timeLimit);
    }

    // Stop the game
    public void WinStopGame()
    {
        gameStarted = false;
        timer.StopTimer();
        dataBeingHarvested.SetActive(true);
        this.gameObject.SetActive(false);
    }
    
    public void LooseStopGame()
    {
        gameStarted = false;
        timer.StopTimer();
        dataBeingHarvested.SetActive(false);
        failedImage.SetActive(true);
        
        StartCoroutine(SetDisactiveAfterDelay());
    }

    private IEnumerator SetDisactiveAfterDelay( )
    {
        yield return new WaitForSeconds(5);

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
                WinStopGame();
            }

            // Check if the timer has run out
            if (timer.IsTimeUp())
            {
                gameOver = true;
                LooseStopGame();
            }
            
             // Check if the "CMD" key (on Mac) or the "Left Control" key (on Windows) and the "C" key are pressed together
            if ((Input.GetKey(KeyCode.LeftCommand) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.C))
                currentTaps++;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TypingGame : MonoBehaviour
{
    public string[] textsToType;
    public float timeLimit;
    public InputField inputField;
    public TextDisplay textDisplay;
    public Timer timer;
    private bool gameStarted;
    private bool gameOver;
    private string currentText;
    [SerializeField] GameObject dataBeingHarvested;

    // Start the game
    public void StartGame()
    {
        gameStarted = true;
        gameOver = false;
        //inputField.gameObject.SetActive(true);
        currentText = SelectRandomText();
        textDisplay.SetText(currentText);
        timer.StartTimer(timeLimit);
    }

    // Stop the game
    public void LooseStopGame()
    {
        gameStarted = false;
        timer.StopTimer();
        HackButton.Fire_onSetActivity(true);
        dataBeingHarvested.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void WinStopGame()
    {
        gameStarted = false;
        timer.StopTimer();
        HackButton.Fire_onSetActivity(false);
        dataBeingHarvested.SetActive(true);
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
            // Check if the player's input is correct
            if (inputField.text == currentText)
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
        }
    }

    // Select a random text from the textsToType array
    private string SelectRandomText()
    {
        int index = Random.Range(0, textsToType.Length);
        return textsToType[index];
    }
}

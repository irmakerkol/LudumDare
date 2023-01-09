using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingGame : MonoBehaviour
{
    public string[] textsToType;
    public float timeLimit;
    public TextDisplay textDisplay;
    public Timer timer;
    public int increaseScore = 5;
    
    private bool gameStarted;
    private bool gameOver;
    private string currentText;
    private AudioSource audioSource;

    [SerializeField] GameObject dataBeingHarvested;
    [SerializeField] GameObject failedImage;
    [SerializeField] AudioClip failedSound;
    [SerializeField] TMPro.TMP_InputField inputField;


    // Start the game
    public void StartGame()
    {
        failedImage.SetActive(false);

        gameStarted = true;
        gameOver = false;
        inputField.text = "";
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
        failedImage.SetActive(true);
        audioSource.PlayOneShot(failedSound);
        StartCoroutine(SetDisactiveAfterDelay());
    }

    private IEnumerator SetDisactiveAfterDelay( )
    {
        yield return new WaitForSeconds(5);

        this.gameObject.SetActive(false);
    }

    public void WinStopGame()
    {
        gameStarted = false;
        timer.StopTimer();
        HackButton.Fire_onSetActivity(false);
        dataBeingHarvested.SetActive(true);
        DataBeingHarvested.instance.harvestedDataCounter ++;
        DataBeingHarvested.instance.IncreaseCount(increaseScore);
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

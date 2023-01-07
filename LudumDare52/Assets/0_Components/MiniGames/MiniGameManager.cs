using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    //Typing Game
    public TypingGame typingGame;
    [SerializeField] GameObject typingGamePanel;

    public void StartTypingGame()
    {
        typingGamePanel.SetActive(true);
        typingGame.StartGame();
    }

    public void StopTypingGame()
    {
        typingGame.WinStopGame();
        typingGamePanel.SetActive(value: false);
    }

    // Check if the TypingGame is complete
    public bool IsTypingGameComplete()
    {
        return typingGame.IsComplete();
    }

    //Button Tapping Game
    public ButtonTappingGame buttonTappingGame;
    [SerializeField] GameObject buttonTappingGamePanel;

    // Start the minigame
    public void StartButtonTappingGame()
    {
        buttonTappingGamePanel.SetActive(value: true);
        buttonTappingGame.StartGame();
    }

    // Stop the minigame
    public void StopButtonTappingGame()
    {
        buttonTappingGame.StopGame();
        buttonTappingGamePanel.SetActive(value: false);
    }

    // Check if the minigame is complete
    public bool IsButtonTappingGameComplete()
    {
        return buttonTappingGame.IsComplete();
    }

}


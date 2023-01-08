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

    // Check if the TypingGame is complete
    public bool IsTypingGameComplete()
    {
        return typingGame.IsComplete();
    }

    //Tapping Game
    public TappingGame tappingGame;
    [SerializeField] GameObject tappingGamePanel;

    // Start the minigame
    public void StartTappingGame()
    {
        tappingGamePanel.SetActive(value: true);
        tappingGame.StartGame();
    }


    // Check if the minigame is complete
    public bool IsButtonTappingGameComplete()
    {
        return tappingGame.IsComplete();
    }

}


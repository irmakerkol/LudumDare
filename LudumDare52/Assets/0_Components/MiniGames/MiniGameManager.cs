using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public TypingGame typingGame;
    [SerializeField] GameObject typingGamePanel;
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

    private void Start()
    {
        StartTypingGame();
    }
    public void StartTypingGame()
    {
        typingGamePanel.SetActive(true);
        typingGame.StartGame();
    }

    public void StopTypingGame()
    {
        typingGame.StopGame();
        typingGamePanel.SetActive(false);
    }

    // Check if the TypingGame is complete
    public bool IsTypingGameComplete()
    {
        return typingGame.IsComplete();
    }
  
}


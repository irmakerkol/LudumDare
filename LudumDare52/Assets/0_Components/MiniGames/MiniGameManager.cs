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
    
    private void Start()
    {
        //bu açýktý ben kapattým - sena
        //StartTappingGame();
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

    public OsuCircleManager osuGame1;
    [SerializeField] GameObject osuGame1Panel;

    // Start the minigame
    public void StartOsuGame1()
    {
        osuGame1Panel.SetActive(value: true);
        osuGame1.Init();
    }

    public OsuCircleManager osuGame2;
    [SerializeField] GameObject osuGame2Panel;

    // Start the minigame
    public void StartOsuGame2()
    {
        osuGame2Panel.SetActive(value: true);
        osuGame2.Init();
    }

    public OsuCircleManager osuGame3;
    [SerializeField] GameObject osuGame3Panel;

    // Start the minigame
    public void StartOsuGame3()
    {
        osuGame3Panel.SetActive(value: true);
        osuGame3.Init();
    }

    [SerializeField] GameObject bugGame;

    // Start the minigame
    public void StartBugGame()
    {
        bugGame.SetActive(value: true);
    }

    [SerializeField] GameObject hardBugGame;

    // Start the minigame
    public void StartHardBugGame()
    {
        hardBugGame.SetActive(value: true);
    }
}


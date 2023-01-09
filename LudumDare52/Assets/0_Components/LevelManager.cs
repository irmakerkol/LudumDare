using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance { get; private set; }
    public int completedLevelNumber = 0;
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

    public void Start()
    {
        StartLevel1();
    }

    [SerializeField] GameObject AmazOffPanel;
    public void StartLevel1()
    {
        AmazOffPanel.SetActive(true);
        completedLevelNumber++;
    }

    [SerializeField] GameObject LinkedOutPanel;
    public void StartLevel2()
    {
        AmazOffPanel.SetActive(false);
        LinkedOutPanel.SetActive(true);
        completedLevelNumber++;
    }

    [SerializeField] GameObject InstakilosPanel;
    public void StartLevel3()
    {
        LinkedOutPanel.SetActive(false);
        InstakilosPanel.SetActive(true);
        completedLevelNumber++;
    }

    [SerializeField] GameObject BlueditPanel;
    public void StartLevel4()
    {
        InstakilosPanel.SetActive(false);
        BlueditPanel.SetActive(true);
        completedLevelNumber++;
    }

    [SerializeField] GameObject DontBlinkPanel;
    public void StartLevel5()
    {
        BlueditPanel.SetActive(false);
        DontBlinkPanel.SetActive(true);
        completedLevelNumber++;
    }

    [SerializeField] GameObject QuitterPanel;
    public void StartLevel6()
    {
        DontBlinkPanel.SetActive(false);
        QuitterPanel.SetActive(true);
        completedLevelNumber++;
    }

    [SerializeField] GameObject OurPipePanel;
    public void StartLevel7()
    {
        QuitterPanel.SetActive(false);
        OurPipePanel.SetActive(true);
        completedLevelNumber++;
    }

    [SerializeField] GameObject NetclicksPanel;
    public void StartLevel8()
    {
        OurPipePanel.SetActive(false);
        NetclicksPanel.SetActive(true);
        completedLevelNumber++;
    }


}

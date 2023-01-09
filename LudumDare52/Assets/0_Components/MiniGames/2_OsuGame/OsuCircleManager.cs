using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OsuCircleManager : MonoBehaviour
{
    public RectTransform[] uiTransforms;
    public float[] times;
    public GameObject failPanel;
    private RectTransform rt;
    public AudioClip success;
    public AudioClip fail;
    public AudioSource audioSource;
    [SerializeField] GameObject dataBeingHarvested;

    private bool gameEnd = true;

    float currentTime;
    int currentCircle;
    bool circlePresent;
    float decrementPerSeconds;
    int increaseScore = 5;

    /*void Start()
    {
        Init();
    }*/

    public void Init()
    {
        gameEnd = true;
        foreach(var transform in uiTransforms)
        {
            transform.gameObject.SetActive(false);
        }
        failPanel.SetActive(false);

        circlePresent = false;
        currentCircle = 0;
        uiTransforms[0].gameObject.SetActive(true);
        decrementPerSeconds = (float)2.0f / times[currentCircle];
        Debug.Log(decrementPerSeconds);
        circlePresent = true;
        currentTime = times[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (!circlePresent && currentCircle < uiTransforms.Length)
        {
            decrementPerSeconds = (float) 2.0f / (float) times[currentCircle];
            Debug.Log(decrementPerSeconds);
            currentTime = times[currentCircle];
            uiTransforms[currentCircle].gameObject.SetActive(true);
            circlePresent = true;
        }
        if(circlePresent && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            rt = uiTransforms[currentCircle].gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
            //Debug.Log(new Vector3(decrementPerSeconds, decrementPerSeconds, decrementPerSeconds));
            rt.localScale -= new Vector3(decrementPerSeconds * Time.deltaTime, decrementPerSeconds * Time.deltaTime , decrementPerSeconds * Time.deltaTime);
            //rt.localScale = new Vector3(1.5f,1.5f,1.5f);
        }

        if(currentTime <= 0 && gameEnd)
        {
            uiTransforms[currentCircle].gameObject.SetActive(false);
            rt.localScale = new Vector3(3, 3, 3);
            LooseStopGame();
            gameEnd = false;

        }
        if(currentCircle == uiTransforms.Length && gameEnd)
        {
            //audioSource.PlayOneShot(success);
            Invoke("WinStopGame", 0.5f);
            gameEnd = false;
        }
        
    }

    /*private void OnEnable()
    {
        Init();
    }*/

    public void increment()
    {
        audioSource.PlayOneShot(success);
        uiTransforms[currentCircle].gameObject.SetActive(false);
        circlePresent = false;
        rt.localScale = new Vector3(3, 3, 3);
        currentCircle++;
    } 

    /*public void winState()
    {
        Debug.Log("wine girdi valla");
        gameObject.SetActive(false);
        //kazanýnca ne olacak 
    }*/

    /*public void failState()
    {
        foreach (var t in uiTransforms)
        {
            t.gameObject.SetActive(false);
        }
  
        failPanel.SetActive(true);
    }*/

    public void LooseStopGame()
    {
        //gameStarted = false;
        HackButton.Fire_onSetActivity(true);
        dataBeingHarvested.SetActive(false);
        foreach (var t in uiTransforms)
        {
            t.gameObject.SetActive(false);
        }
        failPanel.SetActive(true);
        audioSource.PlayOneShot(fail);
        StartCoroutine(SetDisactiveAfterDelay());
    }

    private IEnumerator SetDisactiveAfterDelay()
    {
        yield return new WaitForSeconds(5);

        this.gameObject.SetActive(false);
    }

    public void WinStopGame()
    {
        //gameStarted = false;
        HackButton.Fire_onSetActivity(false);
        dataBeingHarvested.SetActive(true);
        DataBeingHarvested.instance.harvestedDataCounter++;
        DataBeingHarvested.instance.IncreaseCount(increaseScore);
        this.gameObject.SetActive(false);
    }

    // Check if the game is over
    /*public bool IsComplete()
    {
        return gameOver;
    }*/
}

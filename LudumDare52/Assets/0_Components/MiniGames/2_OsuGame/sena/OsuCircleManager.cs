using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsuCircleManager : MonoBehaviour
{
    public RectTransform[] uiTransforms;
    public float[] times;
    public GameObject failPanel;
    private RectTransform rt;

    float currentTime;
    int currentCircle;
    bool circlePresent;
    float decrementPerSeconds;

    void Start()
    {
        Init();
    }

    private void Init()
    {
        Debug.Log("Started");
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
            Debug.Log("kuculuyor.");
            currentTime -= Time.deltaTime;
            rt = uiTransforms[currentCircle].gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
            //Debug.Log(new Vector3(decrementPerSeconds, decrementPerSeconds, decrementPerSeconds));
            rt.localScale -= new Vector3(decrementPerSeconds * Time.deltaTime, decrementPerSeconds * Time.deltaTime , decrementPerSeconds * Time.deltaTime);
            //rt.localScale = new Vector3(1.5f,1.5f,1.5f);
        }

        if(currentTime <= 0)
        {
            uiTransforms[currentCircle].gameObject.SetActive(false);
            Debug.Log("Time up");
            rt.localScale = new Vector3(3, 3, 3);
            failState();
            //gameObject.SetActive(false);

        }
        if(currentCircle == uiTransforms.Length)
        {
            winState();
        }
        
    }

    private void OnEnable()
    {
        Init();
    }

    public void increment()
    {
        uiTransforms[currentCircle].gameObject.SetActive(false);
        circlePresent = false;
        rt.localScale = new Vector3(3, 3, 3);
        currentCircle++;
    } 

    public void winState()
    {
        Debug.Log("wine girdi valla");
        gameObject.SetActive(false);
        //kazanýnca ne olacak 
    }

    public void failState()
    {
        foreach (var t in uiTransforms)
        {
            t.gameObject.SetActive(false);
        }
  
        failPanel.SetActive(true);
    }
}

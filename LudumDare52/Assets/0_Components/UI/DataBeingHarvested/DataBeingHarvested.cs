using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataBeingHarvested : MonoBehaviour
{
    public static DataBeingHarvested instance { get; private set; }
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

    [SerializeField] TMP_Text counterText;
    public int harvestedDataCounter = 0;

    public void IncreaseCount(int increaseAmount)
    {
        StartCoroutine(routine: ChangeText(increaseAmount));
    }

    // Coroutine that changes the text every 2 seconds for count times
    private IEnumerator ChangeText(int count)
    {
        // Repeat count times
        for (int i = 0; i < count; i++)
        {
            // Wait 2 seconds
            yield return new WaitForSeconds(2.0f);

            // Change the text
            harvestedDataCounter ++;
            counterText.text = harvestedDataCounter.ToString();
        }

        
    }

}

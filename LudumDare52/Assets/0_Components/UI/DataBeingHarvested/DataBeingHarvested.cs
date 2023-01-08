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

    public void SetText()
    {
        counterText.text = "" + harvestedDataCounter;
    }
}

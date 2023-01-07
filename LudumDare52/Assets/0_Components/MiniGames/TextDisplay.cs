using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDisplay : MonoBehaviour
{
    public TMP_Text textComponent;

    // Set the text to display
    public void SetText(string text)
    {
        textComponent.text = text;
    }
}


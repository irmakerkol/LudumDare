using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputField : MonoBehaviour
{
    // Reference to the InputField component
    private TMPro.TMP_InputField inputField;

    private void Start()
    {
        // Get a reference to the InputField component
        inputField = GetComponent<TMPro.TMP_InputField>();
    }

    // Get the current text input
    public string text
    {
        get { return inputField.text; }
    }
}


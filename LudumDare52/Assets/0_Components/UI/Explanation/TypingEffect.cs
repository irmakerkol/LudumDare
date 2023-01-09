using TMPro;
using UnityEngine;


public class TypingEffect : MonoBehaviour
{
    // The text to be displayed, divided into parts
    public string[] textParts;

    // The index of the current part of the text
    private int textPartIndex = 0;

    // The text that has been typed so far
    private string typedText = "";

    // The minimum and maximum typing speeds, in characters per second
    public float minTypeSpeed = 0.1f;
    public float maxTypeSpeed = 0.5f;

    // The elapsed time since the last character was typed
    private float elapsedTime = 0f;

    private TextMeshProUGUI WrittenText;
    private void Awake()
    {
        WrittenText = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        // If all of the text has been displayed
        if (textPartIndex >= textParts.Length)
        {
            // Stop the typing effect
            return;
        }

        // Update the elapsed time
        elapsedTime += Time.deltaTime;

        // If enough time has passed to type the next character
        if (elapsedTime >= Random.Range(minTypeSpeed, maxTypeSpeed))
        {
            // Reset the elapsed time
            elapsedTime = 0f;

            // If the typed text is shorter than the current text part
            if (typedText.Length < textParts[textPartIndex].Length)
            {
                // Append the next character to the typed text
                typedText += textParts[textPartIndex][typedText.Length];

                // Update the text displayed by the Text component
                WrittenText.text = typedText;
            }
        }
    }

    public void NextTextPart()
    {
        // If all of the text has been displayed
        if (textPartIndex >= textParts.Length)
        {
            // Start the animation
            GetComponent<Animation>().Play();
            return;
        }

        // If the current text part is not complete
        if (typedText.Length < textParts[textPartIndex].Length)
        {
            // Complete the current text part
            typedText = textParts[textPartIndex];

            // Update the text displayed by the Text component
            WrittenText.text = typedText;
            return;
        }

        // Go to the next text part
        textPartIndex++;

        // Reset the typed text for the new text part
        typedText = "";
    }

    public void onESC()
    {
        LevelManager.instance.StartLevel1();
        Destroy(gameObject);
    }
}

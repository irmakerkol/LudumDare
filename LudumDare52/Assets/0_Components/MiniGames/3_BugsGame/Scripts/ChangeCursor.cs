using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeCursor : MonoBehaviour
{
    //private SpriteRenderer sprRenderer;
    public float shrinkDuration = 0.5f; // Duration of the grow animation
    public Vector2 growAmount; // Amount by which the cursor grows
    private Vector2 originalSize; // Original size of the cursor
    private AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip shootSound; // Sound to play when the cursor is clicked
    
    private RectTransform uiElementRectTransform;
    public Vector3 offset;
    public RectTransform BasisObject;
    public Camera cam;

    public bool isClickable = true; // Flag to keep track of whether the cursor is clickable

    private void Awake()
    {
        Cursor.visible = false;
        audioSource = GetComponent<AudioSource>(); // Get a reference to the AudioSource component
        uiElementRectTransform = GetComponent<RectTransform>(); // Get a reference to the RectTransform component
    }
    private void Start()
    {
        originalSize = uiElementRectTransform.localScale; // Get the original size of the cursor
    }
    /**
     * Old Update
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Get the position of the cursor
        transform.position = cursorPos;

        if (Input.GetMouseButtonDown(0) && isClickable)
        {
            // play the audioclip
            audioSource.PlayOneShot(shootSound);
            //sprRenderer.size += growAmount;
            transform.localScale += (Vector3)growAmount;

            StartCoroutine(ShrinkCursor());
            isClickable = false;
        }
    }
    */
    void Update()
    {
        // Get the mouse position in screen space
        Vector3 mousePos = Input.mousePosition + offset;
        mousePos.z = BasisObject.position.z;
        // Convert the mouse position to canvas space
        uiElementRectTransform.position = cam.ScreenToWorldPoint(mousePos);

        if (Input.GetMouseButtonDown(0) && isClickable)
        {
            // play the audioclip
            audioSource.PlayOneShot(shootSound);
            //sprRenderer.size += growAmount;
            transform.localScale += (Vector3)growAmount;

            StartCoroutine(ShrinkCursor());
            isClickable = false;
        }
}

    // Coroutine to animate the scale of the cursor
    IEnumerator ShrinkCursor()
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < shrinkDuration)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalSize, elapsedTime / shrinkDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = originalSize;
        isClickable = true;
    }
}
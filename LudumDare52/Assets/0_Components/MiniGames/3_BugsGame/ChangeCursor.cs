using UnityEngine;
using System.Collections;

public class ChangeCursor : MonoBehaviour
{
    //private SpriteRenderer sprRenderer;
    public float shrinkDuration = 0.5f; // Duration of the grow animation
    public Vector2 growAmount; // Amount by which the cursor grows
    private Vector2 originalSize; // Original size of the cursor

    public bool isClickable = true; // Flag to keep track of whether the cursor is clickable

    private void Awake()
    {
        //sprRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        Cursor.visible = false;
        originalSize = transform.localScale;
    }

    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Get the position of the cursor
        transform.position = cursorPos;

        if (Input.GetMouseButtonDown(0) && isClickable)
        {

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
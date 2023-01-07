using UnityEngine;
using System.Collections;

public class ChangeCursor : MonoBehaviour
{
    private SpriteRenderer sprRenderer;
    public float shrinkDuration = 0.5f; // Duration of the grow animation
    public Vector2 growAmount; // Amount by which the cursor grows

    public bool isClickable = true; // Flag to keep track of whether the cursor is clickable

    private void Awake()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        Cursor.visible = false;
        growAmount = new Vector2(1.5f, 1.5f);
    }

    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Get the position of the cursor
        transform.position = cursorPos;

        if (Input.GetMouseButtonDown(0) && isClickable)
        {

            sprRenderer.size += growAmount;

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
            sprRenderer.size = Vector3.Lerp(sprRenderer.size, Vector2.one, elapsedTime / shrinkDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        sprRenderer.size = Vector2.one;
        isClickable = true;
    }
}
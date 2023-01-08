using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explanation : MonoBehaviour
{
    public float timeToDestroy;

    private void Start()
    {
        // Start the coroutine to destroy the GameObject after the specified time
        StartCoroutine(DestroyAfterDelay(timeToDestroy));
    }

    // Coroutine that destroys the GameObject after a delay
    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        LevelManager.instance.StartLevel1();
        Destroy(gameObject);
    }

    public void onESC()
    {
        LevelManager.instance.StartLevel1();
        Destroy(gameObject);
    }
}

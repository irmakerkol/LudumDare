using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explanation : MonoBehaviour
{
    [SerializeField] float timeToDestroy;

    private void Start()
    {
        // Destroy the GameObject after the specified time
        Destroy(gameObject, timeToDestroy);
    }

    public void onESC()
    {
        Destroy(gameObject);
    }
}

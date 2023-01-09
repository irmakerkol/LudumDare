using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeApp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("exitGame", 8.0f);
    }

    // Update is called once per frame
    private void exitGame()
    {
        Application.Quit();
    }
}

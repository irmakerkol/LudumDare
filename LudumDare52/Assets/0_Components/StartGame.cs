using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("changeScene", 3.0f);
    }

    // Update is called once per frame
    private void changeScene()
    {
        SceneManager.LoadScene("IntroScene");
    }
}

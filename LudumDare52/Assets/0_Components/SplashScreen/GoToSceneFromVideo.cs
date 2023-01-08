using UnityEngine.Video;
using UnityEngine;
using System.Collections;

public class GoToSceneFromVideo : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public string sceneName;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }
    void Start()
    {
        StartCoroutine(waitUntilVideoEnd());
    }

    IEnumerator waitUntilVideoEnd()
    {
        yield return new WaitForSeconds((float)videoPlayer.length);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
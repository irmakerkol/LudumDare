using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DataBeingHarvested : MonoBehaviour
{
    private AudioSource audioSource;
    
    
    public static DataBeingHarvested instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    [SerializeField] TMP_Text counterText;
    public int harvestedDataCounter = 0;

    public void IncreaseCount(int increaseAmount)
    {
        StartCoroutine(routine: ChangeText(increaseAmount));

    }

    // Coroutine that changes the text every 2 seconds for count times
    private IEnumerator ChangeText(int count)
    {
        // Repeat count times
        for (int i = 0; i < count; i++)
        {
            // Wait 2 seconds
            yield return new WaitForSeconds(0.5f);

            // Change the text
            harvestedDataCounter ++;
            counterText.text = harvestedDataCounter.ToString();
            audioSource.PlayOneShot(audioSource.clip);
        }
        switch (LevelManager.instance.completedLevelNumber)
        {
            case 1:
                LevelManager.instance.StartLevel2();
                break;

            case 2:
                LevelManager.instance.StartLevel3();
                break;

            case 3:
                LevelManager.instance.StartLevel4();
                break;

            case 4:
                LevelManager.instance.StartLevel5();
                break;

            case 5:
                LevelManager.instance.StartLevel6();
                break;

            case 6:
                LevelManager.instance.StartLevel7();
                break;

            case 7:
                LevelManager.instance.StartLevel8();
                break;

            case 8:
                //finish game
                Debug.Log("oyunu bitirdin helal");
                SceneManager.LoadScene("EndScene");
                break;
        }
        gameObject.SetActive(false);
    }

}

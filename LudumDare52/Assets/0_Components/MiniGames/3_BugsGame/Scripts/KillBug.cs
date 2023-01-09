using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBug : MonoBehaviour
{
    public string targetTag;
    private AudioSource audioSource;
    public AudioClip deathSound;
    [SerializeField] GameObject dataBeingHarvested;
    [SerializeField] GameObject gameCanvas;
    private int increaseScore = 5;
    

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null && hit.collider.tag == targetTag)
            {
                // play the audioclip
                audioSource.PlayOneShot(deathSound);

                hit.collider.gameObject.GetComponent<Animator>().Play("deadBug");
                hit.collider.gameObject.GetComponent<FollowBezierCurve>().enabled = false;
                Invoke("WinStopGame", 2.0f);

            }
        }
    }

    public void WinStopGame()
    {
        Cursor.visible = true;
        HackButton.Fire_onSetActivity(false);
        dataBeingHarvested.SetActive(true);
        DataBeingHarvested.instance.harvestedDataCounter++;
        DataBeingHarvested.instance.IncreaseCount(increaseScore);
        gameCanvas.SetActive(false);
    }
}

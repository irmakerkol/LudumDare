using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBug : MonoBehaviour
{
    public string targetTag;
    public Sprite deadSprite;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null && hit.collider.tag == targetTag)
            {
                hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = deadSprite;
                hit.collider.gameObject.GetComponent<FollowBezierCurve>().enabled = false;
            }
        }
    }
}

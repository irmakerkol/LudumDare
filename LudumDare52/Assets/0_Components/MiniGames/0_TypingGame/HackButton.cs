using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackButton : MonoBehaviour
{
    public static Action<bool> onSetActivity;
    public static void Fire_onSetActivity(bool trueOrFalse) { onSetActivity?.Invoke(trueOrFalse); }

    private void Awake()
    {
        onSetActivity += SetActivity;
    }
    public void SetActivity(bool trueOrFalse)
    {
        gameObject.SetActive(trueOrFalse);
    }
}

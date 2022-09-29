using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class TimeCountdown : MonoBehaviour
{
    [SerializeField] float startTime = 45f;

    public Text timerText;

    private bool isTiming = false;

    void Update()
    {
        if (isTiming == false)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                isTiming = true;
            }
        }

        if (isTiming)
        {
            UpdateTime();
        }
    }
    
    private void UpdateTime()
    {
        startTime -= Time.deltaTime;
        timerText.text = TimeToString(startTime);
    }
    string TimeToString(float t)
    {
        string seconds = (t % 60).ToString("f2");
        return seconds;
    }
}


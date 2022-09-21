using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;

    bool keepTiming;
    float timer;

    Collision collision;

    void Start()
    {
        collision = GetComponent<Collision>();
        StartTimer();
    }

    void Update()
    {
        if (collision.finishLevel == true)
        {
            Debug.Log("Timer stopped at " + TimeToString(StopTimer()));
        }

        if (keepTiming)
        {
            UpdateTime();
        }
    }

    void UpdateTime()
    {
        timer = Time.time - startTime;
        timerText.text = TimeToString(timer);
    }

    float StopTimer()
    {
        keepTiming = false;
        return timer;
    }

    void StartTimer()
    {
        keepTiming = true;
        startTime = Time.time;
    }

    string TimeToString(float t)
    {
        string seconds = (t % 60).ToString("f2");
        return seconds;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text score;
    public Text timerText;
    private float startTime;

    bool keepTiming = false;
    float timer;

    Collision collision;

    void Start()
    {   
        collision = GetComponent<Collision>();
    }

    void Update()
    {
        if (keepTiming == false)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                StartTimer();
                keepTiming = true;
            }
        }

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
        score.text = TimeToString(timer);
    }

    float StopTimer()
    {
        keepTiming = false;
        return timer;
    }

    public void StartTimer()
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

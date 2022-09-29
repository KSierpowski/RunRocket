using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class TimeCountdown : MonoBehaviour
{
    [SerializeField] public float startTime = 45f;
    [SerializeField] Canvas gameOverCanvas;

    public Text timerText;
    AudioSource audioSource;

    private bool isTiming = false;
    public bool gameOver = false;

    private void Start()
    {
        gameOverCanvas.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        TimeOver();
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
    private void TimeOver()
    {
        if(startTime <= 0)
        {
            gameOver = true;
            audioSource.Stop();
            gameOverCanvas.enabled = true;
            GetComponent<Movement>().enabled = false;
        }

    }

    private void UpdateTime()
    {
        if(startTime > 0)
        {
            startTime -= Time.deltaTime;
            timerText.text = TimeToString(startTime);
        }
        else
        {
            gameOver = true;
        }

    }
    string TimeToString(float t)
    {
        string seconds = (t % 60).ToString("f2");
        return seconds;
    }
}


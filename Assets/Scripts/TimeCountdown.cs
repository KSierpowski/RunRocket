using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class TimeCountdown : MonoBehaviour
{
    [SerializeField] public float startTime = 45f;
    [SerializeField] Canvas gameOverCanvas;

    public TextMeshProUGUI timerText;
    AudioSource audioSource;
    Collision collision;

    private bool isTiming = false;
    public bool gameOver = false;

    private void Start()
    {
        gameOverCanvas.enabled = false;
        audioSource = GetComponent<AudioSource>();
        collision = GetComponent<Collision>();
    }
    void Update()
    {
        StopTimer();
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
            collision.StopAllCoroutines();
        }

    }

    private void StopTimer()
    {
        if (collision.finishLevel == true)
        {
            isTiming = false;
        }
    }

    private void UpdateTime()
    {
        if(startTime > 0)
        {
            startTime -= Time.deltaTime;
            timerText.text = FormatTime(startTime);
        }
        else
        {
            gameOver = true;
        }

    }
    string FormatTime(float time)
    {
        int intTime = (int)time;
        int minutes = intTime / 60;
        int seconds = intTime % 60;
        float fraction = time * 1000;
        fraction = (fraction % 100);
        string timeText = String.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
        return timeText;
    }
}


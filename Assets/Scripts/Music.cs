using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] Canvas muteImage;
    [SerializeField] AudioClip mainSong;
    public bool mute = false;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        Mute();
    }

    private void Mute()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {

            mute = !mute;
            if (mute == false)
            {
                audioSource.mute = false;
                muteImage.enabled = false;
            }
            else
            {
                audioSource.mute = true;
                muteImage.enabled = true;
            }
        }
    }
}

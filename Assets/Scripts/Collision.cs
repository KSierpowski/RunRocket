using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    [SerializeField] float loadDelay = 2f;

    public AudioClip explosion;
    public AudioClip success;

    public ParticleSystem explosionParticles;
    public ParticleSystem successParticles;

    AudioSource audioSource;

    bool isTransparently = false;
    public bool finishLevel = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (isTransparently) return;

        switch (collision.gameObject.tag)
        {
            case "Respawn":
                break;

            case "Finish":
                StartCoroutine(NextLevelSequences());
                break;

            default:
                {
                    StartCoroutine(CrashSequences());
                    break ;
                }
        }
    }
    private IEnumerator CrashSequences()
    {
        isTransparently = true;
        audioSource.Stop();
        audioSource.PlayOneShot(explosion);
        explosionParticles.Play();
        GetComponent<Movement>().enabled = false;
        yield return new WaitForSeconds(loadDelay);
        GetComponent<EndGameHandler>().CrashHandler();
    }

    private IEnumerator NextLevelSequences()
    {
        isTransparently = true;
        finishLevel = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        yield return new WaitForSeconds(loadDelay);
        GetComponent<EndGameHandler>().Score();
        GetComponent<EndGameHandler>().SuccessHandler();
    }


}

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
                NextLevelSequences();
                break;

            default:
                {
                    CrashSequences();
                    break ;
                }
        }
    }

    void CrashSequences()
    {
        isTransparently = true;
        audioSource.Stop();
        audioSource.PlayOneShot(explosion);
        explosionParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }

    void NextLevelSequences()
    {
        isTransparently = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", loadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int nextSceneLoad;

    private void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    public void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

        Time.timeScale = 1;
    }

    public void LoadNextLevel()
    {
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(nextSceneLoad);
        if (nextSceneLoad > PlayerPrefs.GetInt("levelReached"))
        {
            PlayerPrefs.SetInt("levelReached", nextSceneLoad);
        }


    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }


    public void QuitGame()
    {
        Application.Quit();
    }

}


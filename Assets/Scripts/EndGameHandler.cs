using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    void Start()
    {
        gameOverCanvas.enabled = false;
    }
public void CrashHandler()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

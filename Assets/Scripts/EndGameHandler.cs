using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameHandler : MonoBehaviour
{
    [SerializeField] Canvas successCanvas;
    [SerializeField] Canvas crashCanvas;

    void Start()
    {
        successCanvas.enabled = false;
        crashCanvas.enabled = false;
    }
public void SuccessHandler()
    {
        successCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CrashHandler()
    {
        crashCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

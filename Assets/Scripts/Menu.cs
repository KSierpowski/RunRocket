using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    GameObject menu;

    private void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Menu");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            menu.SetActive(false);
        }
    }

}

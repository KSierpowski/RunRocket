using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    [SerializeField] public float maxFuel = 100f;
    [SerializeField] float currentFuel = 100f;
    [SerializeField] float fuelUsage = 1f;

    [SerializeField] Slider slider;

    void Start()
    {
        maxFuel = currentFuel;
    }

    void Update()
    {
        DecreaseFuel();
        SliderDisplay();
    }

    public float DecreaseFuel()
    {
        if (Input.GetKey(KeyCode.S))
        {
            currentFuel -= fuelUsage/1000;
        }
        return currentFuel;
    }

    private void SliderDisplay()
    {
        slider.value = currentFuel/100;
    }

}

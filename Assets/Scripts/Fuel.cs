using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    [SerializeField] public float maxFuel = 100f;
    [SerializeField] float currentFuel = 100f;
    [SerializeField] float fuelUsage = 1f;

    void Start()
    {
        maxFuel = currentFuel;
    }

    void Update()
    {
        DecreaseFuel();
    }

    public float DecreaseFuel()
    {
        if (Input.GetKey(KeyCode.S))
        {
            currentFuel -= fuelUsage/1000;
        }
        return currentFuel;
    }


}

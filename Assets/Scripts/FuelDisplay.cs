using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelDisplay : MonoBehaviour
{
    Fuel fuel;
    private void Awake()
    {
        fuel = GameObject.FindWithTag("Player").GetComponent<Fuel>();
    }

    private void Update()
    {
       GetComponent<Text>().text = String.Format("{0:0}/{1:0}", fuel.DecreaseFuel(), fuel.maxFuel);
    }

}

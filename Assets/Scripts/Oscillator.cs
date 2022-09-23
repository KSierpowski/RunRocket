using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] Vector3 movementVector;
    float  movementFactor;
    [SerializeField] float period = 2f;


    void Start()
    {
        startingPos = transform.position; 
    }


    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;  

        const float tau = Mathf.PI * 2;     
        float rawSinWave = Mathf.Sin(tau * cycles);   

        movementFactor = (rawSinWave + 1f) / 2f;             

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}

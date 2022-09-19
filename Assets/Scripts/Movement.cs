using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 500f;
    
    
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ProcessThrust();
        
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrust();
        }
    }

    private void StartThrust()
    {
       rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
    }
    private void StopThrust()
    {

    }

}

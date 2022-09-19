using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 500f;
    [SerializeField] float rotationThrust = 100f;
    
    
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrust();
        }

    }
    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            RotationThrust(rotationThrust);
        }
        if (Input.GetKey(KeyCode.A))
        {
            RotationThrust(-rotationThrust);
        }
    }
    private void StartThrust()
    {
       rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
    }
    private void StopThrust()
    {

    }
    private void RotationThrust(float rotation)
    {
        transform.Rotate(Vector3.forward * rotation * Time.deltaTime);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 500f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] ParticleSystem mainEngine;
    [SerializeField] ParticleSystem leftEngine;
    [SerializeField] ParticleSystem rightEngine;

    AudioSource audioSource;
    [SerializeField] AudioClip engineSound;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = rb.GetComponent<AudioSource>();
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
        else
        {
            StopThrust();
        }

    }
    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
           
        else if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else
        {
            StopRotate();
        }
            
    }

    private void RotateLeft()
    {
            RotationThrust(-rotationThrust);
            if (!leftEngine.isPlaying)
            {
                leftEngine.Play();
            }
    }

    private void RotateRight()
    {
            RotationThrust(rotationThrust);
            if (!rightEngine.isPlaying)
            {
                rightEngine.Play();
            }
    }

    private void StartThrust()
    {
       rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!mainEngine.isPlaying)
        {
            mainEngine.Play();
        }
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(engineSound);
        }
       ;
    }
    private void StopThrust()
    {
        audioSource.Stop();
        mainEngine.Stop();
    }
    private void RotationThrust(float rotation)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotation * Time.deltaTime);
        rb.freezeRotation = false;
    }
    private void StopRotate()
    {
        rightEngine.Stop();
        leftEngine.Stop();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    [SerializeField] float lightDecay = 1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minAngle = 20f;

    Light rocketLight;

    private void Start()
    {
        rocketLight = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        rocketLight.spotAngle = restoreAngle;
    }
    public void RestoreLightIntensity(float intensityAmount)
    {
        rocketLight.intensity += intensityAmount;
    }


    void DecreaseLightAngle()
    {
        if (rocketLight.spotAngle > minAngle)
        {
            rocketLight.spotAngle -= angleDecay * Time.deltaTime;

        }

    }
    void DecreaseLightIntensity()
    {
        rocketLight.intensity -= lightDecay * Time.deltaTime;

    }

}

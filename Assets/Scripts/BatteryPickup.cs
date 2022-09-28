using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 60f;
    [SerializeField] float intensityAmount = 15;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<Lights>().RestoreLightAngle(restoreAngle);
            FindObjectOfType<Lights>().RestoreLightIntensity(intensityAmount);
            Destroy(gameObject);
        }
    }
}

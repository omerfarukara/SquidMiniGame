using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAreaController : MonoBehaviour
{
    [SerializeField] ParticleSystem confetti;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bot"))
        {
            other.GetComponent<OtherController>().IsPassed = true;
        }

        if (other.CompareTag("Player"))
        {
            other.GetComponent<SwerveMovement>().IsPassed = true;
            confetti.Play();
        }
       
    }
}

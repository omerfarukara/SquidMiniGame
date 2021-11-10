using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPlayerController : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystem;

    Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ShotOn(Transform playerTransform)
    {
        transform.LookAt(playerTransform);
        _animator.SetTrigger("Fire");
        particleSystem.Play();
    }
}

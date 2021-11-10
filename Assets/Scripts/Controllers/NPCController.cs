using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystem;
    
    Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ShotOn(Transform botTransform)
    {
        transform.LookAt(botTransform);
        _animator.SetTrigger("Fire");
        particleSystem.Play();
        botTransform.gameObject.GetComponent<OtherController>().Stun();
    }
}

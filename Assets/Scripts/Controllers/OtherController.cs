using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherController : MonoBehaviour
{
    [SerializeField] GreenLight greenLight;
    [SerializeField] float mainSpeed;
    [SerializeField] float differanceSpeed;
    [SerializeField] float differanceTime;

    Animator _animator;

    float _speed;
    float _currentTime;
    bool _isRun;
    bool _running;
    bool _stopped;
    bool _isStun;
    bool _isPassed;

    public bool IsRun
    {
        get
        {
            return _isRun;
        }
        set
        {
            _isRun = value;
        }
    }

    public bool IsPassed
    {
        get
        {
            return _isPassed;
        }
        set
        {
            if (value)
            {
                _animator.SetTrigger("Victory");
            }
            _isPassed = value;
        }
    }

    void Awake()
    {
        _animator = GetComponent<Animator>();
        greenLight.GreenLightOnEventHandler += GreenLightOn;
    }

    void Update()
    {
        if (_isStun ||_isPassed) return;

        if (_isRun)
        {
            _currentTime -= Time.deltaTime;
            OtherRun();
            if (_currentTime <= 0)
            {
                _isRun = false;
            }
        }
        else
        {
            OtherStop();
        }
    }

    void GreenLightOn()
    {
        _isRun = true;
         _currentTime = Random.Range(greenLight.LigthTimer - differanceTime, greenLight.LigthTimer + differanceTime);
    }

    public void OtherRun()
    {
        if (!_running)
        {
            _running = true;
            _stopped = false;
            _animator.SetBool("Run", true);
            _speed = Random.Range(mainSpeed - differanceSpeed, mainSpeed + differanceSpeed);
            transform.Translate(Vector3.forward * _speed);
        }
        else
        {
            transform.Translate(Vector3.forward * _speed);
        }
    }

    public void OtherStop()
    {
        if (!_stopped)
        {
            _stopped = true;
            _running = false;
            _animator.SetBool("Run", false);
            transform.Translate(Vector3.zero);
        }
    }

    public void Stun()
    {
        _isStun = true;
        _animator.SetTrigger("Stun");
    }

}

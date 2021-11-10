using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherMovementController : MonoBehaviour
{

    [SerializeField] OtherController otherController;
    //[SerializeField] RedLight redLight;
    [SerializeField] GreenLight greenLight;
    [SerializeField] float differance;

    int _randomTime;
    float _currentTime;

    void Start()
    {
        RandomRange();
    }
    void Update()
    {
        _currentTime -= Time.deltaTime;
        if (_currentTime == 0)
        {
            otherController.OtherStop();
         //   redLight.WaitSecond -= Time.deltaTime;
        }
        //if (redLight.WaitSecond == 0)
        //{
        //    RandomRange();
        //}
    }

    void RandomRange()
    {
        _randomTime = (int)Random.Range(greenLight.LigthTimer - differance, greenLight.LigthTimer + differance);
        _currentTime = _randomTime;
        otherController.OtherRun();
        Debug.Log("MPC'ler için tanýmlanan randomTime = " + _randomTime);
    }
}

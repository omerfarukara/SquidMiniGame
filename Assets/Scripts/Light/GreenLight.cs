using System.Collections;
using UnityEngine;

public delegate void GreenLightOnEventHandler();

public class GreenLight : MonoBehaviour
{
   public event GreenLightOnEventHandler GreenLightOnEventHandler;

    [SerializeField] RedLight _redLight;
    Light _light;

    int RandomTime;
    int _lightTimer;
    bool _turnRed;

    public bool TurnRed
    {
        get
        {
            return _turnRed;
        }
        set
        {
            _turnRed = value;
        }
    }
    public int LigthTimer
    {
        get
        {
            return _lightTimer;
        }
        set
        {
            _lightTimer = value;
        }
    }

    void Awake()
    {
        _light = GetComponent<Light>();
    }

    void Start()
    {
        _light.intensity = 0;
        RandomTimeFunc();
    }

    void FixedUpdate()
    {
        if (_redLight.TurnGreen && _lightTimer == 0)
        {
            RandomTimeFunc();
            _redLight.TurnGreen = false;
        }
    }

    void RandomTimeFunc()
    {
        RandomTime = (int)Random.Range(2f, 8f);
        _lightTimer = RandomTime;
        GreenLightOnEventHandler();
        StartCoroutine(LightTime());
        _lightTimer = RandomTime;
    }

    IEnumerator LightTime()
    {
        _light.intensity = 5;
        yield return new WaitForSeconds(RandomTime);
        _lightTimer = 0;
        _light.intensity = 0;
        TurnRed = true;
    }
}

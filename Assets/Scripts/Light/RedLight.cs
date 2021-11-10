using System.Collections;
using UnityEngine;

public class RedLight : MonoBehaviour
{
    [SerializeField] GreenLight _greenLight;
    [SerializeField] float _maxWaitSecond;
    [SerializeField] float _minWaitSecond;

    Light _light;

    bool _turnGreen;
    bool _onLight;
    float _waitSecond;

    public bool TurnGreen
    {
        get
        {
            return _turnGreen;
        }
        set
        {
            _turnGreen = value;
        }
    }

    public bool OnLight
    {
        get
        {
            return _onLight;
        }
        set
        {
            _onLight = value;
        }
    }

    void Awake()
    {
        _light = GetComponent<Light>();
    }

    void Start()
    {
        _light.intensity = 0;
    }

    void Update()
    {
        if (_greenLight.LigthTimer == 0 && _greenLight.TurnRed)
        {
            _waitSecond = Random.Range(_minWaitSecond, _maxWaitSecond);
            StartCoroutine(RedEnumarator(_waitSecond));
            _greenLight.TurnRed = false;
        }
    }

    IEnumerator RedEnumarator(float delay)
    {
        _light.intensity = 5;
        _onLight = true;
        yield return new WaitForSeconds(delay);
        _onLight = false;
        _light.intensity = 0;
        TurnGreen = true;
    }
}

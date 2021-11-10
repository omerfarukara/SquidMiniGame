using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    SwerveInputSystem _swerveInputSystem;
    [SerializeField] float rotateSpeed;
    [SerializeField] float swerveSpeedX = 0.5f;
    [SerializeField] float maxSwerveAmount = 0.1f;
    [SerializeField] float speed;

    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject WinPanel;

    [SerializeField] RedLight redLight;
    [SerializeField] NPCPlayerController nPCPlayerController;

    Animator _animator;

    bool _isStun;
    bool _isRun;
    bool _isPassed;
    float timer = 3;

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
                WinPanel.SetActive(true);
            }
            _isPassed = value;
        }
    }

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _swerveInputSystem = GetComponent<SwerveInputSystem>();
    }

    void Update()
    {
        if (_isStun || _isPassed) return;
        

        SwerveAmountX();

        if (Input.GetMouseButton(0))
        {
            _isRun = true;
            transform.Translate(0, 0, speed);
            _animator.SetBool("Run", true);

            if (_swerveInputSystem.MoveFactorX > 0)
            {
                transform.Rotate(0, rotateSpeed, 0);
            }
            else if (_swerveInputSystem.MoveFactorX < 0)
            {
                transform.Rotate(0, -rotateSpeed, 0);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            transform.Translate(0, 0, 0);
            _animator.SetBool("Run", false);
            _isRun = false;
        }

        if (redLight.OnLight && _isRun && !_isPassed)
        {
            nPCPlayerController.ShotOn(transform);
            Stun();
            GameOverPanel.SetActive(true);

        }
    }


    void SwerveAmountX()
    {
        float swerveAmountX = swerveSpeedX * Time.deltaTime * _swerveInputSystem.MoveFactorX;
        swerveAmountX = Mathf.Clamp(swerveAmountX, -maxSwerveAmount, maxSwerveAmount);
        transform.Translate(swerveAmountX, 0, 0);
    }

    public void Stun()
    {
        _isStun = true;
        _animator.SetTrigger("Stun");
    }
}

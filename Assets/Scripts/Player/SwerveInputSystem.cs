using UnityEngine;

public class SwerveInputSystem : MonoBehaviour
{
    float _lastFrameFingerPositionX;
    float _moveFactorX;

    public float MoveFactorX => _moveFactorX;
       
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _moveFactorX = 0f;
        }
    }
}

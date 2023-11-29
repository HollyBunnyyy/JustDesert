using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera _inputCamera;

    [SerializeField]
    private InputHandler _inputHandler;

    [SerializeField]
    private float _mouseSensitivity = 2.0f;

    private Vector3 _targetCameraRotation;

    protected void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    protected void Update()
    {
        _inputCamera.transform.localEulerAngles = GetClampedTargetRotation();
    }

    public Vector3 GetClampedTargetRotation( float minYAngle = -89.0f, float maxYAngle = 89.0f )
    {
        _targetCameraRotation.x = Mathf.Clamp( _targetCameraRotation.x - _inputHandler.MouseDelta.y * _mouseSensitivity, minYAngle, maxYAngle );
        _targetCameraRotation.y += _inputHandler.MouseDelta.x;

        return _targetCameraRotation;
    }
}

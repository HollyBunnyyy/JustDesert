using UnityEngine;

public class CameraInputHandler : MonoBehaviour
{
    // Mouse sensitivity will be handled in its own player prefs file - WIP for now.
    [SerializeField]
    private float _mouseSensitivity = 2.0f;

    [SerializeField]
    private InputHandler _inputHandler;

    private Vector3 _targetCameraRotation;

    /// <summary>
    /// Returns the current frame's mouse delta clamped between the minimum and maximum y angle.
    /// </summary>
    public Vector3 GetMouseInputClamped( float minYAngle = -90.0f, float maxYAngle = 90.0f )
    {
        _targetCameraRotation.x = Mathf.Clamp( _targetCameraRotation.x - _inputHandler.MouseDelta.y * _mouseSensitivity, minYAngle, maxYAngle );
        _targetCameraRotation.y += _inputHandler.MouseDelta.x * _mouseSensitivity;

        return _targetCameraRotation;
    }
}

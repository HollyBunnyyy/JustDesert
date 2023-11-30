using UnityEngine;

public class ThirdPersonCameraState : CameraState
{
    [SerializeField]
    private Camera _inputCamera;

    [SerializeField]
    private Transform _transformToFollow;

    [SerializeField]
    private CameraInputHandler _cameraInputHandler;

    [SerializeField]
    private Vector3 _cameraOffset = new Vector3( 0.0f, 0.0f, -5.0f );

    public override void OnStateUpdate()
    {
        _inputCamera.transform.localEulerAngles = _cameraInputHandler.GetMouseInputClamped();
        _inputCamera.transform.position = _inputCamera.transform.rotation * _cameraOffset + _transformToFollow.position;
    }
}

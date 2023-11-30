using UnityEngine;

public class FirstPersonCameraState : CameraState
{
    [SerializeField]
    private Camera _inputCamera;

    [SerializeField]
    private Transform _transformToFollow;

    [SerializeField]
    private CameraInputHandler _cameraInputHandler;

    public override void OnStateUpdate()
    {
        _inputCamera.transform.position = _transformToFollow.position;
        _inputCamera.transform.localEulerAngles = _cameraInputHandler.GetMouseInputClamped();
    }
}

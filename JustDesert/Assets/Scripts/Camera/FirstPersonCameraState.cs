using UnityEngine;

[RequireComponent( typeof( CameraInputHandler ) )]
public class FirstPersonCameraState : CameraState
{
    [SerializeField]
    private Camera _inputCamera;

    [SerializeField]
    private Transform _transformToFollow;

    private CameraInputHandler _cameraInputHandler;

    protected void Awake()
    {
        _cameraInputHandler = GetComponent<CameraInputHandler>();
    }

    public override void OnStateUpdate()
    {
        _inputCamera.transform.position = _transformToFollow.position;
        _inputCamera.transform.localEulerAngles = _cameraInputHandler.GetMouseInputClamped();
    }
}

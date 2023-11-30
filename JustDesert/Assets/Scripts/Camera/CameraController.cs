using UnityEngine;

[RequireComponent( typeof( CameraInputHandler ) )]
public class CameraController : CameraStateMachine
{
    protected void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}

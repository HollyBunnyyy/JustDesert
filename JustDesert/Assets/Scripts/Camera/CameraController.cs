using UnityEngine;

public class CameraController : CameraStateMachine
{
    protected void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}

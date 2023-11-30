using UnityEngine;

public abstract class CameraState : MonoBehaviour, IState<CameraState>
{
    public abstract void OnStateUpdate();
}

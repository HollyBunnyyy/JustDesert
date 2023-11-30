using UnityEngine;

public class CameraStateMachine : MonoBehaviour, IStateMachine<CameraState>
{
    [SerializeField]
    private CameraState _cameraState;

    protected void Update()
    {
        if( _cameraState == null )
        {
            return;

        }

        _cameraState.OnStateUpdate();

    }

    public CameraState GetState()
    {
        return _cameraState;
    }

    public void SetState( CameraState stateToSet )
    {
        _cameraState = stateToSet;
    }
}

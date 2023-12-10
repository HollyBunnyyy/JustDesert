using UnityEngine;

public class MotorStateMachine : MonoBehaviour, IStateMachine<MotorState>
{
    [SerializeField]
    private MotorState _motorState;

    protected void Update()
    {
        if( _motorState == null )
        {
            return;
        }

        _motorState.OnStateUpdate();

    }

    public MotorState GetState()
    {
        return _motorState;
    }

    public void SetState( MotorState stateToSet )
    {
        _motorState = stateToSet;
    }
}

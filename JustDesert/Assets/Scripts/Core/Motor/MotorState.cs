using UnityEngine;

public abstract class MotorState : MonoBehaviour, IState<MotorState>
{
    public abstract void OnStateUpdate();
}

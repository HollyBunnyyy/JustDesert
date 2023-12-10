using UnityEngine;

public class WalkingMotorState : MotorState
{
    [SerializeField]
    private float _movementSpeed = 5.0f;

    [SerializeField]
    private float _movementFriction = 25.0f;

    [SerializeField]
    private AnimationCurve _frictionCurve;

    [SerializeField]
    private RigidbodyMotor _rigidbodyMotor;

    public override void OnStateUpdate()
    {
        

    }

}

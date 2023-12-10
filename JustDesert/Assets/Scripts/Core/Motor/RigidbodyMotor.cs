using UnityEngine;

public class RigidbodyMotor : MonoBehaviour
{
    public Vector3 Velocity => _rigidbody.velocity;

    private Vector3 _targetVelocity;
    private Vector3 _targetAcceleration;
    private Vector3 _gravityScalar = new Vector3( 1.0f, 0.0f, 1.0f );

    [SerializeField]
    private Rigidbody _rigidbody;

    public void ApplyFrictionForce( Vector3 directionToApply, float forceToApply, float frictionToApply )
    {
        // Calculates the position between the current velocity and target velocity by moving 'frictionToApply' units.
        // Note this is different from Vector3.Lerp as lerp calculates T as a percentage, where this calculates it as units.
        _targetVelocity = Vector3.MoveTowards( _targetVelocity, directionToApply * forceToApply, frictionToApply * Time.fixedDeltaTime );

        // Calculates the amount of force to apply based off the difference of the rigidbody's current velocity and
        // the desired target velocity - also works as a corrective force if the rigidbody's velocity is higher than
        // the given targetVelocity.
        _targetAcceleration = ( _targetVelocity - _rigidbody.velocity ) / Time.fixedDeltaTime;

        // This limits the amount of force that can be applied by the acceleration amount.
        // Since the formula above can act as a 'corrective force' it's also important to limit how much it can
        // correct by otherwise it will just instantly stop and feel unrealistic. 
        _targetAcceleration = Vector3.ClampMagnitude( _targetAcceleration, frictionToApply );

        // Finally, apply our desired acceleration amount.
        // Scaling the acceleration by gravity stops the targetAcceleration algorithm from ALSO correcting gravity
        // which is necesary because otherwise our player could not fall at all if this is applied every frame. 
        _rigidbody.AddForce( Vector3.Scale( _targetAcceleration, _gravityScalar ) * _rigidbody.mass );

    }

    public void ApplyInstantForce( Vector3 directionToApply, float forceToApply )
    {
        _rigidbody.AddForce((( directionToApply * forceToApply ) - _rigidbody.velocity ) / Time.fixedDeltaTime );
    }

}
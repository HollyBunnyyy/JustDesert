using UnityEngine;

public class RigidbodyMotor : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;

    private Vector3 _movementVelocity;

    protected void FixedUpdate()
    {
        _rigidbody.AddRelativeForce( ( _movementVelocity - _rigidbody.velocity ) * _rigidbody.mass / Time.fixedDeltaTime );

    }

    /// <summary>
    /// Moves the rigidbody along the given direction axis.
    /// </summary>
    public void MoveTowards( Vector3 directionToMoveTowards, float movementSpeed )
    {
        _movementVelocity = directionToMoveTowards * movementSpeed;
    }
}
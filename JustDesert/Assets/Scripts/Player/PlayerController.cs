using UnityEngine;

// TODO : The speed, friction, and friction curve can all be moved to their own class - right now this is WIP.
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _interactionDistance = 2.0f;

    [SerializeField]
    private float _movementSpeed = 5.0f;

    [SerializeField]
    private float _movementFriction = 25.0f;

    [SerializeField]
    private AnimationCurve _frictionCurve;

    [SerializeField]
    private CameraDirectionGimble _cameraDirectionGimble;

    [SerializeField]
    private CameraRaycaster _cameraRaycaster;

    [SerializeField]
    private InputHandler _inputHandler;

    [SerializeField]
    private RigidbodyMotor _rigidbodyMotor;

    private float _velocityDirectionDelta;
    private float _frictionToApply;

    private Vector3 _inputDirection;

    private bool _isTouchingGround;

    protected void Update()
    {
        _inputDirection = _cameraDirectionGimble.transform.TransformDirection( _inputHandler.WASDAxis );

        if( Input.GetKeyDown( KeyCode.E ) )
        {
            if( _cameraRaycaster.TryGetCurrentObjectInView( _interactionDistance, out GameObject gameObjectInView ) )
            {
                gameObjectInView.TryGetComponent( out IInteractable interactable );

                interactable?.OnInteract( gameObject );

            }
        }
    }

    protected void FixedUpdate()
    {
        _isTouchingGround = Physics.Raycast( transform.position, -transform.up, 1.0f );

        _velocityDirectionDelta = Vector3.Dot( _inputDirection, _rigidbodyMotor.Velocity.normalized );

        _frictionToApply = _movementFriction * _frictionCurve.Evaluate( _velocityDirectionDelta );

        if( _isTouchingGround )
        {
            _rigidbodyMotor.ApplyFrictionForce( _inputDirection, _movementSpeed, _frictionToApply );

        }
    }

}


/*
    _springForce = Physics.gravity.y * ( _raycastHitInfo.distance - PlayerHeight );

    _rigidbody.AddForce( (( transform.up * _springForce ) - _rigidbody.velocity ) * _rigidbody.mass / Time.fixedDeltaTime );
    _rigidbody.AddForce( _movementDirection * MovementSpeed );

 */

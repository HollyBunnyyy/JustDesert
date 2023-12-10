using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeederController : MonoBehaviour
{
    [SerializeField]
    private InputHandler _inputHandler;

    [SerializeField]
    private float _hoverHeight = 2.0f;

    [SerializeField]
    private float _hoverStrength = 5.0f;

    [SerializeField]
    private float _hoverDampening = 0.5f;

    public float HoverGrip;

    [SerializeField]
    private Rigidbody _rigidbody;

    private RaycastHit _raycastHitInfo;

    private Vector3 _groundNormal;

    private float _hoverVelocity => Vector3.Dot( transform.up, _rigidbody.GetPointVelocity( _rigidbody.position ) );
    private float _hoverCompression => _raycastHitInfo.distance - _hoverHeight;
    private float _hoverForce => ( _hoverCompression * _hoverStrength ) - ( _hoverVelocity * _hoverDampening );

    protected void FixedUpdate()
    {
        if( Physics.Raycast( transform.position, -transform.up, out _raycastHitInfo, _hoverHeight ) )
        {
            _groundNormal = _raycastHitInfo.normal.normalized;

            Vector3 groundProjection = Vector3.ProjectOnPlane( transform.forward, _groundNormal );

            Quaternion rotation = Quaternion.LookRotation( groundProjection, _groundNormal );

            _rigidbody.MoveRotation( Quaternion.Lerp( _rigidbody.rotation, rotation, 5.0f * Time.fixedDeltaTime ) );
            _rigidbody.AddForce( _groundNormal * _hoverForce );

            float steeringVelocity = Vector3.Dot( transform.right, _rigidbody.GetPointVelocity( transform.position ) );

            float desiredChange = ( -steeringVelocity * HoverGrip ) / Time.fixedDeltaTime;

            _rigidbody.AddForceAtPosition( transform.right * 0.5f * desiredChange, transform.position );

            _rigidbody.AddForceAtPosition( transform.forward * ( _inputHandler.WASDAxis.z * 5.0f ), transform.position );

            //_rigidbody.AddRelativeTorque( 0.0f, _inputHandler.WASDAxis.x - _rigidbody.angularVelocity.y, 0.0f, ForceMode.VelocityChange );

            //_rigidbody.AddForce( sideFriction );

        }
    }
}

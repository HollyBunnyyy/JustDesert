using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 5.0f;

    [SerializeField]
    private CameraDirectionGimble _cameraDirectionGimble;

    [SerializeField]
    private InputHandler _inputHandler;

    [SerializeField]
    private RigidbodyMotor _rigidbodyMotor;

    private Vector3 _movementDirection;

    protected void FixedUpdate()
    {
        _movementDirection = _cameraDirectionGimble.transform.TransformDirection( _inputHandler.WASDAxis );
        _movementDirection.Normalize();

        _rigidbodyMotor.MoveTowards( _movementDirection, MovementSpeed );

    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawSphere( -transform.up * 1.0f, 0.5f );

    }

}

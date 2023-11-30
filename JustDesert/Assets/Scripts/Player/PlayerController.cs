using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 5.0f;

    [SerializeField]
    private Camera _inputCamera;

    [SerializeField]
    private RigidbodyMotor _rigidbodyMotor;

    [SerializeField]
    private InputHandler _inputHandler;

    private Vector3 _movementDirection;

    protected void Update()
    {
        _movementDirection = _inputCamera.transform.TransformDirection( _inputHandler.WASDAxis );

        _rigidbodyMotor.MoveTowards( _movementDirection, MovementSpeed );

    }
}

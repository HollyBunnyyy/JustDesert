using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorController : MonoBehaviour
{
    [SerializeField]
    private RigidbodyMotor _rigidbodyMotor;

    [SerializeField]
    private float _movementSpeed = 5.0f;

    [SerializeField]
    private float _movementFriction = 25.0f;

    [SerializeField]
    private AnimationCurve _frictionCurve;


    private float _velocityDirectionDelta;


}

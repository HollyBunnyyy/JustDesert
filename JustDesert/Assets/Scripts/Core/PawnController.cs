using UnityEngine;

[RequireComponent( typeof( Rigidbody ), typeof( CapsuleCollider ) )]
public class PawnController : MonoBehaviour
{
    [SerializeField]
    protected Rigidbody Rigidbody;

    [SerializeField]
    protected CapsuleCollider Collider;

    protected void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Collider  = GetComponent<CapsuleCollider>();
    }
}

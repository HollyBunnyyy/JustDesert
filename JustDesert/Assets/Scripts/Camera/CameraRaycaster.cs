using UnityEngine;

public class CameraRaycaster : MonoBehaviour
{
    private RaycastHit _raycastHitInfo;
    public RaycastHit RaycastHitInfo => _raycastHitInfo;

    [SerializeField]
    private Camera _camera;

    protected void FixedUpdate()
    {
        Physics.Raycast( _camera.transform.position, _camera.transform.forward, out _raycastHitInfo );

    }

    /// <summary>
    /// Attempts to get the current object in front of the camera.
    /// </summary>
    public bool TryGetCurrentObjectInView( out GameObject objectInView )
    {
        objectInView = _raycastHitInfo.collider ? _raycastHitInfo.collider.gameObject : null;

        return objectInView;

    }

    /// <summary>
    /// Attempts to get the current object in front of the camera and within the given view distance.
    /// </summary>
    public bool TryGetCurrentObjectInView( float viewDistance, out GameObject objectInView )
    {
        TryGetCurrentObjectInView( out objectInView );

        if( objectInView == null || Vector3.Distance( transform.position, objectInView.transform.position ) > viewDistance )
        {
            return false;
        }

        return true;

    }
}

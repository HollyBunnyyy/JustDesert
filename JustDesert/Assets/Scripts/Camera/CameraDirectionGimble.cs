using UnityEngine;

public class CameraDirectionGimble : MonoBehaviour
{
    [SerializeField]
    private Camera _inputCamera;

    private Vector3 _isolatedCameraAngle;

    public void Update()
    {
        _isolatedCameraAngle.y = _inputCamera.transform.eulerAngles.y;

        transform.eulerAngles = _isolatedCameraAngle;

    }
}

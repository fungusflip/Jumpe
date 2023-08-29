using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] Transform target;  // The object the camera should follow
    [SerializeField] float smoothSpeed = 0.125f;  // How smoothly the camera should follow
    [SerializeField] float maxXPosition = 10.0f; // The maximum X position for the camera

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position;  // Get the target's position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);  // Smoothly interpolate

            // Limit the camera's X position to the specified maximum
            smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, -Mathf.Infinity, maxXPosition);

            transform.position = smoothedPosition;  // Update camera's position
        }
    }
}

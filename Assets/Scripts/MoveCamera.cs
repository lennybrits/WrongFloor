using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraAnchor;  // assign the player's head/anchor in Inspector

    void LateUpdate()
    {
        if (cameraAnchor != null)
        {
            // Position the camera exactly at the anchor
            transform.position = cameraAnchor.position;
			Vector3 euler = transform.eulerAngles;
            transform.rotation = Quaternion.Euler(euler.x, cameraAnchor.eulerAngles.y, euler.z);
            // Rotation is controlled by MouseLook, so don't overwrite it here
        }
    }
}

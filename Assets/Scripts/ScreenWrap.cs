
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
   

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void LateUpdate()
    {
        if (mainCamera == null)
            return;

        Vector3 position = transform.position;

        // Convert the player's position to screen viewport coordinates.
        Vector3 viewportPosition =
            mainCamera.WorldToViewportPoint(position);

        bool wrapped = false;

        // Left edge -> right edge
        if (viewportPosition.x < 0f)
        {
            viewportPosition.x = 1f;
            wrapped = true;
        }
        // Right edge -> left edge
        else if (viewportPosition.x > 1f)
        {
            viewportPosition.x = 0f;
            wrapped = true;
        }

        // Bottom edge -> top edge
        if (viewportPosition.y < 0f)
        {
            viewportPosition.y = 1f;
            wrapped = true;
        }
        // Top edge -> bottom edge
        else if (viewportPosition.y > 1f)
        {
            viewportPosition.y = 0f;
            wrapped = true;
        }

        if (wrapped)
        {
            // Preserve the player's original depth from the camera.
            Vector3 newPosition =
                mainCamera.ViewportToWorldPoint(viewportPosition);

            newPosition.z = position.z;
            transform.position = newPosition;
        }
    }
}

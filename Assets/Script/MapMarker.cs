using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMarker : MonoBehaviour
{
    public Transform target;  // Reference to your base or target
    public Canvas canvas;     // Reference to the canvas containing the marker

    void Update()
    {
        if (target != null && canvas.renderMode == RenderMode.WorldSpace)
        {
            // Convert world position to screen space
            Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position);

            // Update the position of the marker on the canvas
            transform.position = screenPos;
        }
    }

    void LateUpdate()
    {
        // Make the marker always face the camera
        transform.LookAt(Camera.main.transform);
    }
}

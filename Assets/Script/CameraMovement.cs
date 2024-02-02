using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector3 offset; // Offset to adjust the camera's position relative to the player
    private Transform target;

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = desiredPosition;
    }
    private void Start() {
        GameObject _gameobject = GameObject.FindWithTag("Player");
        target = _gameobject.transform;
    }
}

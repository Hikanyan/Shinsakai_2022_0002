using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
     [SerializeField] private float _cameraSpeed = 100f;
    void Update()
    {
        float y = Input.GetAxis("Mouse X");
        float x = Input.GetAxis("Mouse Y");

        transform.rotation = Quaternion.Euler(y * _cameraSpeed, x * _cameraSpeed, 0);
    }
}

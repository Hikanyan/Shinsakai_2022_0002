using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CursorController : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook _cinemachineFreeLook;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0)
        {
            Debug.Log("oku");
        }
        if (scroll < 0)
        {
            Debug.Log("temae");
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Cursor.visible=true;
            Cursor.lockState=CursorLockMode.None;
        }
        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

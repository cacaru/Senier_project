using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 카메라 이동 스크립트
public class move : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    private float xRotation = 0f;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {     //키입력
        mouseMovement();
    }

    // 카메라이동
    void mouseMovement() {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, 0f, 0f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void cursorMovement() {
        Cursor.lockState = CursorLockMode.None;
    }

    public void cursorContinue() {
        Cursor.lockState = CursorLockMode.Locked;
    }
}

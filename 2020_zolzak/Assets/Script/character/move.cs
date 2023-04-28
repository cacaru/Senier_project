using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 카메라 이동 스크립트
public class move : MonoBehaviour
{

    private float mouseSensitivity = 50f;

    public Transform playerBody;

    private float xRotation = 0f;
    private Vector3 init;
    private Vector3 cam_pos;
    public bool can_mouse_move = false;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update() {     //키입력
        mouseMovement();
    }

    // 카메라이동
    void mouseMovement() {

        if (can_mouse_move) {
            // 마우스 움직인 값 받아오기
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
                    
            //xRotation - 카메라 회전 값 변수 - 초기값 :: 0f
            xRotation -= mouseY;

            //카메라 상하 각도 최대치 설정
            xRotation = Mathf.Clamp(xRotation, -50f, 50f);
            // 카메라 움직이는 값 설정
            // vector3.up           :: 움직일 방향
            // mousSensitivity      :: 마우스 감도 값
            // Time.smoothDeltaTime :: 프레임에 맞게 부드럽게 움직이기 위한 변수
            // -mouse Y             :: 직접 움직인 값 ( 시야가 위로가면 카매라는 아래로 내려가야 하므로 - )
            cam_pos = Vector3.up * mouseSensitivity * Time.smoothDeltaTime * -mouseY / 10;
            
            //상하 움직임
            if ( (xRotation > 10f && xRotation < 50f) || (xRotation < -10f && xRotation > -50f) ) {
                // 시야를 아래로 내릴때 카메라 위치는 위로
                // 시야를 위로 올릴때 카메라 위치는 아래로
                transform.Translate(cam_pos, Space.World);
            }
            
            // 캐릭터의 local space 축을 카메라가 바라보는 방향에 맞게 회전
            // 유니티 :: 회전을 위해 Quaternion을 사용
            // x축의 방향만 직접 변경 할 것이므로 Euler 함수 사용
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            // 캐릭터가 보는 방향을 마우스가 바라보는 방향으로 바꿈
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }

    public void cursorMovement() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void cursorContinue() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

//카메라 상하 이동
//transform.Translate(Vector3.up * mouseSensitivity * Time.smoothDeltaTime * mouseY, Space.World);
//카메라 정면 이동
//transform.Translate(Vector3.forward * mouseSensitivity * Time.smoothDeltaTime * mouseY, Space.World);

/*if (xRotation < 10f && xRotation > -20f)
    transform.position = init;*/

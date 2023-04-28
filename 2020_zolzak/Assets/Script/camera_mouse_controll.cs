using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_mouse_controll : MonoBehaviour
{
    public float rotateSpeed = 10.0f;
    public float zoomSpeed = 10.0f;

    private Camera mainCamera;

    public GameObject target;//추적할 대상

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Zoom();
        Rotate();
    }

    private void Zoom() {
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;
        //마우스 휠의 입력을 받아서 줌 스피드 만큼 곱해 MainCamera의 fieldOfView 속성값에 누적해준다.
        if (distance != 0)
            mainCamera.fieldOfView += distance;
    }

    private void Rotate() {

        if (Input.GetMouseButton(1)) {
            Vector3 rot = transform.rotation.eulerAngles; //현제 카메라의 각도를 Vector3로 변환

            rot.y += Input.GetAxis("Mouse X") * rotateSpeed; //마우스 X위치 * 회전 스피드
            rot.x += -1 * Input.GetAxis("Mouse Y") * rotateSpeed; //마우스 Y위치 * 회전 스피드

            Quaternion q = Quaternion.Euler(rot); //Quaternion으로 변환
            q.x = q.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, q, 2f); //자연스럽게 회전
        }
    }
}

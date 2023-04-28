using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_camera : MonoBehaviour
{
    
    public Transform target;            //추적할 타겟 오브젝트 
    public float dist = 10.0f;          //카메라와의 거리
    public float height = 5.0f;         //카메라의 높이
    public float smoothRotate = 5.0f;   //부드러운 회전변수\

    private Transform tr;               //카메라 자신의 Transform 변수
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //부드러운 회전 함수 Mathf.LerpAngle
        float currYAnagle = Mathf.LerpAngle(tr.eulerAngles.y, target.eulerAngles.y,
            smoothRotate * Time.deltaTime);

        //오일러 -> 쿼터니언
        Quaternion rot = Quaternion.Euler(0, currYAnagle, 0);

        //카메라를 target에 맞게 이동
        tr.position = target.position - (rot * Vector3.forward * dist) + (Vector3.up * height);

        //시야를 타겟에게
        tr.LookAt(target);
    }


}

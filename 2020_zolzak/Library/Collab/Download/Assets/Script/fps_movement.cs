using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 캐릭터 이동 스크립트
public class fps_movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 10f;

    // Update is called once per frame
    void Update() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }
}

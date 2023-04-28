using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_smooth : MonoBehaviour
{
    public GameObject _target;
    public Vector3 _iniPos;
    public Vector3 _nowPos;

    // Use this for initialization
    void Start()
    {

        _iniPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = _iniPos + _target.transform.position;

    }
}

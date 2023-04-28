using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    Vector3 goal;
    // Start is called before the first frame update
    void Start()
    {
        goal = transform.position;
        goal.z += 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Robot Kyle")
        {
            GameObject.Find("Mana").GetComponent<TestMapSC>().goal();
            Debug.Log("["+collision.gameObject.name+"]");
        }
    }
}

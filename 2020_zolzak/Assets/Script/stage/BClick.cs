using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BClick : MonoBehaviour {

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SendStage()
    {
        GameObject.Find("StageManager").GetComponent<btn_controller>().Movescene(gameObject.ToString());
    }
}

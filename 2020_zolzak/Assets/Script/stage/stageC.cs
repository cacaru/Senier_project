using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class stageC : MonoBehaviour
{
    public string whatbutton;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scroll = GameObject.Find("Canvas").transform.Find("Panel").transform.Find("Scrollbar").gameObject;
        scroll.GetComponent<Scrollbar>().value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

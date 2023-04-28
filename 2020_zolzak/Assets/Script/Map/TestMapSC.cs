using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMapSC : MonoBehaviour
{
    string cobj;
    GameObject clearS;
    public GameObject clear;
    public Vector3 CR;
    public Vector3 viewW;
    public Vector3 searchC;
    GameObject constollC;
    GameObject Cbox;
    GameObject[] cubes;

    // Start is called before the first frame update
    void Start()
    {
        GameObject clearS = GameObject.Find("Sphere");
        Cbox = GameObject.Find("cube");
        cubes = new GameObject[Cbox.transform.childCount];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    public void TouchWaht(string name)
    {
        Debug.Log(name);
        cobj = name;
    }
    public void DoPullmove()
    {
        GameObject.Find(cobj).GetComponent<cubeG>().pullonoff();
        // 캐릭터의 위치를 뒤로가게끔

    }
    public void DoPushmove()
    {
        GameObject.Find(cobj).GetComponent<cubeG>().pushonoff();
        // 캐릭터의 위치를 앞으로 가게끔


    }
    */
    public void goal()
    {
        if (clear.activeSelf)
            clear.SetActive(false);
        else
            clear.SetActive(true);
        Time.timeScale = 0;
        GameObject.Find("Sight").GetComponent<move>().cursorMovement();
    }
    public void receiveCharacterR(Vector3 v, Vector3 Sv)
    {
        CR = v;
        viewW = Sv;
        searchC = CR + viewW;
        // Debug.Log("조작하려는 위치/ x: " + searchC.x + ", y: " + searchC.y + ", z: " + searchC.z);
        GameObject.Find("Robot Kyle").GetComponent<character_move>().receiveControllC(searchCube(searchC));
    }
    GameObject searchCube(Vector3 c)
    {
        Vector3 ex;
        bool ist = false ;
        for (int i =1; i<cubes.Length; i++)
        {
            string ojtn = "c" + i.ToString();
            // ex = GameObject.Find(ojtn).transform.position;
            if(GameObject.Find(ojtn) != null){
                ex.x = Mathf.Round(GameObject.Find(ojtn).transform.position.x);
                ex.y = Mathf.Round(GameObject.Find(ojtn).transform.position.y);
                ex.z = Mathf.Round(GameObject.Find(ojtn).transform.position.z);
            }
            else
            {
                ex.x = 0;
                ex.y = 0;
                ex.z = 0;
            }
           //  Debug.Log("받아온 물체: "+GameObject.Find(ojtn).name+" / x: " + ex.x + ", y: " + ex.y + ", z: " + ex.z);
            if (ex == c)
            {
                ist = true;
                constollC = GameObject.Find(ojtn);
            }
        }
        if (ist)
        {
            return constollC;
        }
        else
        {
            return null;
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeG : MonoBehaviour
{
    private GameObject target;
    Vector3 pullgoal;
    Vector3 pushgoal;
    Vector3 viewW;
   
    //Vector3 m_vecTarget;
    //int speed = 10;
    bool pullon = false;
    bool pushon = false;

    int viewCheck = 0;
    GameObject Cbox;
    GameObject[] cubes;
    string myTag = null;

    float cubeSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        //m_vecTarget = transform.position;
        Cbox = GameObject.Find("cube");
        cubes = new GameObject[Cbox.transform.childCount];
        for (int i = 0; i < Cbox.transform.childCount; i++)
        {
            cubes[i] = Cbox.transform.GetChild(i).gameObject;
        }
        myTag = gameObject.tag;
        
    }
    
    /*
    void Update()
    {
        float fMove = Time.deltaTime * speed;
        
        if (Input.GetMouseButtonDown(0))
        {
            target = GetClickedObject();
            if (target.Equals(gameObject))
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                // transform.Translate(Vector3.right * fMove);
                Debug.Log(gameObject.name);
                transform.position = Vector3.MoveTowards(transform.position, goal, 0.5f);
            }
        }
    }
   
    private GameObject GetClickedObject()
    {
        RaycastHit hit;
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //마우스 포인트 근처 좌표를 만든다. 
        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))   //마우스 근처에 오브젝트가 있는지 확
        {
            //있으면 오브젝트를 저장한다.
            target = hit.collider.gameObject;
        }
        return target;
    }
    */
    void Update()
    {
        if(myTag == "splitcube")
        {
            Vector3 can_position;
            can_position.x = Mathf.Round(GameObject.Find("Character").transform.GetChild(0).gameObject.transform.position.x);
            can_position.y = Mathf.Round(GameObject.Find("Character").transform.GetChild(0).gameObject.transform.position.y);
            can_position.z = Mathf.Round(GameObject.Find("Character").transform.GetChild(0).gameObject.transform.position.z);
            Vector3 checkSplitPosition;
            checkSplitPosition.x = Mathf.Round(gameObject.transform.position.x);
            checkSplitPosition.y = Mathf.Round(gameObject.transform.position.y) + 1;
            checkSplitPosition.z = Mathf.Round(gameObject.transform.position.z);
            if (can_position.x == checkSplitPosition.x && can_position.y == checkSplitPosition.y && can_position.z == checkSplitPosition.z)
            {
                Debug.Log("난 split이고 내위에 폭탄이 있어요!!!!!");
                Destroy(gameObject, 2.0f);
            }
        }
        if(pullon)
        {
            transform.position = Vector3.MoveTowards(transform.position, pullgoal, cubeSpeed);
            if (transform.position == pullgoal) {
                pullon = !pullon;
                cubes = new GameObject[Cbox.transform.childCount];
                for (int i = 0; i < Cbox.transform.childCount; i++) {
                    cubes[i] = Cbox.transform.GetChild(i).gameObject;
                }
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
 
        }
        if (pushon)
        {
            transform.position = Vector3.MoveTowards(transform.position, pushgoal, cubeSpeed);
            if (transform.position == pushgoal)
            {
                pushon = !pushon;
                cubes = new GameObject[Cbox.transform.childCount];
                for (int i = 0; i < Cbox.transform.childCount; i++)
                {
                    cubes[i] = Cbox.transform.GetChild(i).gameObject;
                }
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }
    /*
    private GameObject GetClickedObject()
    {
        RaycastHit hit;
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //마우스 포인트 근처 좌표를 만든다. 
        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))   //마우스 근처에 오브젝트가 있는지 확
        {
            //있으면 오브젝트를 저장한다.
            target = hit.collider.gameObject;
        }
        return target;
    }
    */
    private void OnCollisionStay(Collision collision)
    {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
    public void pullonoff(Vector3 v)
    {
        if(myTag == "A18")
        {
            if(GameObject.Find("Main Camera").GetComponent<Timer>().time < 5)
            {
                GameObject.Find("Main Camera").GetComponent<Timer>().time = 1;
            }
            else
            {
                GameObject.Find("Main Camera").GetComponent<Timer>().time -= 5;
            }
        }
        viewW = v;
        Vector3 front;
        front.x = 0.0F; front.y = 0.0F; front.z = 1.0F;
        Vector3 back;
        back.x = 0.0F; back.y = 0.0F; back.z = -1.0F;
        Vector3 left;
        left.x = -1.0F; left.y = 0.0F; left.z = 0.0F;
        Vector3 right;
        right.x = 1.0F; right.y = 0.0F; right.z = 0.0F;
        if (viewW == front)
        {
            if(myTag == "switchcube")
            {
                Debug.Log("switch");
                switchrightset();
            }
            else
            {
                Debug.Log("noswitch");
                frontset2();
            }
        }
        else if (viewW == back)
        {
            if (myTag == "switchcube")
            {
                Debug.Log("switch");
               switchleftset();
            }
            else
            {
                Debug.Log("noswitch");
                backset2();
            }
        }
        else if (viewW == left)
        {
            if (myTag == "switchcube")
            {
                Debug.Log("switch");
                switchfrontset();
            }
            else
            {
                Debug.Log("noswitch");
                leftset2();
            }
        }
        else if (viewW == right)
        {
            if (myTag == "switchcube")
            {
                Debug.Log("switch");
                switchbackset();
            }
            else
            {
                Debug.Log("noswitch");
                rightset2();
            }
        }
        pullon = !pullon;
    }
    public void pushonoff(Vector3 v)
    {
        if (myTag == "A18")
        {
            if (GameObject.Find("Main Camera").GetComponent<Timer>().time < 5)
            {
                GameObject.Find("Main Camera").GetComponent<Timer>().time = 1;
            }
            else
            {
                GameObject.Find("Main Camera").GetComponent<Timer>().time -= 5;
            }
        }
        viewW.x = Mathf.Round(v.x); viewW.y = Mathf.Round(v.y); viewW.z = Mathf.Round(v.z);
        Vector3 front;
        front.x = 0.0F; front.y = 0.0F; front.z = 1.0F;
        Vector3 back;
        back.x = 0.0F; back.y = 0.0F; back.z = -1.0F;
        Vector3 left;
        left.x = -1.0F; left.y = 0.0F; left.z = 0.0F;
        Vector3 right;
        right.x = 1.0F; right.y = 0.0F; right.z = 0.0F;
        if (viewW == front)
        {
            if(myTag == "switchcube")
            {
                Debug.Log("여기 프론트 !!!!!!!!!!!!!");
                leftset();
            }
            else
            {
                frontset();
            }
        }
        else if(viewW == back)
        {
            if (myTag == "switchcube")
            {
                rightset();
            }
            else
            {
                backset();
            }
        }
        else if (viewW == left)
        {
            if (myTag == "switchcube")
            {
                backset();
            }
            else
            {
                leftset();
            }
        }
        else if(viewW == right)
        {
            if (myTag == "switchcube")
            {
                frontset();
            }
            else
            {
                rightset();
            }
        }
        pushon = !pushon;
    }
    //미는 모션
    void frontset()
    {
        int cubeCount = cubes.Length;
        bool move_front = true;
        pushgoal = transform.position;
        pushgoal.z += 1;
        for (int i = 0; i < cubeCount; i++)
        {
            cubeCount = cubes.Length;
            if (cubes[i] == null)
            {
                continue;
            }
            if (Mathf.Round(cubes[i].transform.position.x) == Mathf.Round(pushgoal.x) && Mathf.Round(cubes[i].transform.position.y) == Mathf.Round(pushgoal.y) && Mathf.Round(cubes[i].transform.position.z) == Mathf.Round(pushgoal.z))
            {
                move_front = false;
                // 움직이면 안되니까 원상복구
                character_move.canMove = false;//못움직이도록 설정
                Debug.Log("못움직이도록 설정");
                pushgoal.z -= 1;
                break;
            }
        }
        if (move_front == true)
        {
            if (myTag == "switchcube")
                character_move.canMove = false;
            else
                character_move.canMove = true;//움직이도록 설정
        }
        viewCheck = 1;
    }
    void backset()
    {
        int cubeCount = cubes.Length;
        bool move_back = true;
        pushgoal = transform.position;
        pushgoal.z -= 1;
        for (int i = 0; i < cubeCount; i++)
        {
            cubeCount = cubes.Length;
            if (cubes[i] == null)
            {
                continue;
            }
            if (Mathf.Round(cubes[i].transform.position.x) == Mathf.Round(pushgoal.x) && Mathf.Round(cubes[i].transform.position.y) == Mathf.Round(pushgoal.y) && Mathf.Round(cubes[i].transform.position.z) == Mathf.Round(pushgoal.z))
            {
                move_back = false;
                character_move.canMove = false;//못움직이도록 설정
                pushgoal.z += 1;
                break;
            }
        }
        if (move_back == true)
        {
            if (myTag == "switchcube")
                character_move.canMove = false;
            else
                character_move.canMove = true;//움직이도록 설정
        }
        viewCheck = 2;
    }
    void leftset()
    {
        int cubeCount = cubes.Length;
        bool move_left = true;
        pushgoal = transform.position;
        pushgoal.x -= 1;
        for (int i = 0; i < cubeCount; i++)
        {
            cubeCount = cubes.Length;
            if (cubes[i] == null)
            {
                continue;
            }
            if (Mathf.Round(cubes[i].transform.position.x) == Mathf.Round(pushgoal.x) && Mathf.Round(cubes[i].transform.position.y) == Mathf.Round(pushgoal.y) && Mathf.Round(cubes[i].transform.position.z) == Mathf.Round(pushgoal.z))
            {
                cubeCount = cubes.Length;
                move_left = false;
                character_move.canMove = false;//못움직이도록 설정
                pushgoal.x += 1;
                break;
            }
        }
        if (move_left == true)
        {
            if (myTag == "switchcube")
                character_move.canMove = false;
            else
                character_move.canMove = true;//움직이도록 설정
        }
        viewCheck = 4;
    }
    void rightset()
    {
        int cubeCount = cubes.Length;
        bool move_right = true;
        pushgoal = transform.position;
        pushgoal.x += 1;
        for (int i = 0; i < cubeCount; i++)
        {
            cubeCount = cubes.Length;
            if (cubes[i] == null)
            {
                continue;
            }
            if (Mathf.Round(cubes[i].transform.position.x) == Mathf.Round(pushgoal.x) && Mathf.Round(cubes[i].transform.position.y) == Mathf.Round(pushgoal.y) && Mathf.Round(cubes[i].transform.position.z) == Mathf.Round(pushgoal.z))
            {
                move_right = false;
                character_move.canMove = false;//못움직이도록 설정
                pushgoal.x -= 1;
                break;
            }
        }
        if (move_right == true)
        {
            if (myTag == "switchcube")
                character_move.canMove = false;
            else
                character_move.canMove = true;//움직이도록 설정
        }
        viewCheck = 3;
    }

    //당기는 모션
    void frontset2()
    {
        int cubeCount = cubes.Length;
        bool front_move2 = true;
        bool cubeMoveError = false;
        pullgoal = transform.position;
        pullgoal.z -= 2; 
        for ( int i =0; i<cubes.Length; i++)
        {
            cubeCount = cubes.Length;
            if (cubes[i] == null)
            {
                continue;
            }
            if (Mathf.Round(cubes[i].transform.position.x) == Mathf.Round(pullgoal.x) && Mathf.Round(cubes[i].transform.position.y) == Mathf.Round(pullgoal.y) && Mathf.Round(cubes[i].transform.position.z) == Mathf.Round(pullgoal.z))
            {
                front_move2 = false;
                //움직이면 안되는 경우임 원상복구
                character_move.canMove = false;//못움직이도록 설정
                pullgoal.z += 2;
                cubeMoveError = true;
                break;
            }
        }
        if (!cubeMoveError) 
        {   //1칸만 움직여야됨
            pullgoal.z += 1;
        }
        if(front_move2 == true)
            character_move.canMove = true;//움직이도록 설정
        viewCheck = 1;
    }
    void backset2()
    {
        int cubeCount = cubes.Length;
        bool back_move2 = true;
        bool cubeMoveError = false;
        pullgoal = transform.position;
        pullgoal.z += 2;
        for (int i = 0; i < cubes.Length; i++)
        {
            cubeCount = cubes.Length;
            if (cubes[i] == null)
            {
                continue;
            }
            if (Mathf.Round(cubes[i].transform.position.x) == Mathf.Round(pullgoal.x) && Mathf.Round(cubes[i].transform.position.y) == Mathf.Round(pullgoal.y) && Mathf.Round(cubes[i].transform.position.z) == Mathf.Round(pullgoal.z))
            {
                back_move2 = false;
                character_move.canMove = false;//못움직이도록 설정
                pullgoal.z -= 2;
                cubeMoveError = true;
                break;
            }
        }
        if (!cubeMoveError)
        {
            pullgoal.z -= 1;
        }
        if(back_move2 == true)
            character_move.canMove = true;//움직이도록 설정
        viewCheck = 2;
    }
    void leftset2()
    {
        int cubeCount = cubes.Length;
        bool left_move2 = true;
        bool cubeMoveError = false;
        pullgoal = transform.position;
        pullgoal.x += 2;
        for (int i = 0; i < cubes.Length; i++)
        {
            cubeCount = cubes.Length;
            if (cubes[i] == null)
            {
                continue;
            }
            if (Mathf.Round(cubes[i].transform.position.x) == Mathf.Round(pullgoal.x) && Mathf.Round(cubes[i].transform.position.y) == Mathf.Round(pullgoal.y) && Mathf.Round(cubes[i].transform.position.z) == Mathf.Round(pullgoal.z))
            {
                left_move2 = false;
                character_move.canMove = false;//못움직이도록 설정
                pullgoal.x -= 2;
                cubeMoveError = true;
                break;
            }
        }
        if (!cubeMoveError)
        {
            pullgoal.x -= 1;
        }
        if(left_move2 == true)
            character_move.canMove = true;//움직이도록 설정
        viewCheck = 4;
    }
    void rightset2()
    {
        int cubeCount = cubes.Length;
        bool right_move2 = true;
        bool cubeMoveError = false;
        pullgoal = transform.position;
        pullgoal.x -= 2;
        for (int i = 0; i < cubeCount; i++)
        {
            cubeCount = cubes.Length;
            if(cubes[i] == null)
            {
                continue;
            }
            if (Mathf.Round(cubes[i].transform.position.x) == Mathf.Round(pullgoal.x) && Mathf.Round(cubes[i].transform.position.y) == Mathf.Round(pullgoal.y) && Mathf.Round(cubes[i].transform.position.z) == Mathf.Round(pullgoal.z))
            {
                right_move2 = false;
                character_move.canMove = false;//못움직이도록 설정
                pullgoal.x += 2;
                cubeMoveError = true;
                break;
            }
        }
        if (!cubeMoveError)
        {
            pullgoal.x += 1;
        }
        if(right_move2 == true)
            character_move.canMove = true;//움직이도록 설정
        viewCheck = 3;
    }

    void switchfrontset()
    {
        bool switchfrontmove = true;
        pullgoal = transform.position;
        pullgoal.z += 1;
        for (int i = 0; i < cubes.Length; i++)
        {
            if (cubes[i] == null)
            {
                continue;
            }
            if (Mathf.Round(cubes[i].transform.position.x) == Mathf.Round(pullgoal.x) && Mathf.Round(cubes[i].transform.position.y) == Mathf.Round(pullgoal.y) && Mathf.Round(cubes[i].transform.position.z) == Mathf.Round(pullgoal.z))
            {
                character_move.canMove = false;
                // 캐릭터 무브 안에 있는 불 변수를 false로 해라!
                pullgoal.z -= 1;
                break;
            }
            if (switchfrontmove == true)
                character_move.canMove = false;
            Debug.Log("스위치");
        }
        viewCheck = 1;
    }
    void switchbackset()
    {
        bool switchbackmove = true;
        pullgoal = transform.position;
        pullgoal.z -= 1;
        for (int i = 0; i < cubes.Length; i++)
        {
            if (cubes[i] == null)
            {
                continue;
            }
            if (Mathf.Round(cubes[i].transform.position.x) == Mathf.Round(pullgoal.x) && Mathf.Round(cubes[i].transform.position.y) == Mathf.Round(pullgoal.y) && Mathf.Round(cubes[i].transform.position.z) == Mathf.Round(pullgoal.z))
            {
                character_move.canMove = false;
                pullgoal.z += 1;
                break;
            }
            if (switchbackmove == true)
                character_move.canMove = false;
            Debug.Log("스위치");
        }
        viewCheck = 2;
    }
    void switchleftset()
    {
        bool switchleftmove = true;
        pullgoal = transform.position;
        pullgoal.x -= 1;
        for (int i = 0; i < cubes.Length; i++)
        {
            if (cubes[i] == null)
            {
                continue;
            }
            if (Mathf.Round(cubes[i].transform.position.x) == Mathf.Round(pullgoal.x) && Mathf.Round(cubes[i].transform.position.y) == Mathf.Round(pullgoal.y) && Mathf.Round(cubes[i].transform.position.z) == Mathf.Round(pullgoal.z))
            {
                character_move.canMove = false;
                pullgoal.x += 1;
                break;
            }
            if (switchleftmove == true)
                character_move.canMove = false;
            Debug.Log("스위치");
        }
        viewCheck = 4;
    }
    void switchrightset()
    {
        bool switchrightmove = true;
        pullgoal = transform.position;
        pullgoal.x += 1;
        for (int i = 0; i < cubes.Length; i++)
        {
            if (cubes[i] == null)
            {
                continue;
            }
            if (Mathf.Round(cubes[i].transform.position.x) == Mathf.Round(pullgoal.x) && Mathf.Round(cubes[i].transform.position.y) == Mathf.Round(pullgoal.y) && Mathf.Round(cubes[i].transform.position.z) == Mathf.Round(pullgoal.z))
            {
                character_move.canMove = false;
                pullgoal.x -= 1;
                break;
            }
            if (switchrightmove == true)
                character_move.canMove = false;
            Debug.Log("스위치");
        }
        viewCheck = 3;
    }
}


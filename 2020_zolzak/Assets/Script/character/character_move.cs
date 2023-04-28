using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_move : MonoBehaviour
{
    Vector3 MyRound;
    Vector3 Fojt;
    Vector3 Bojt;
    Vector3 Lojt;
    Vector3 Rojt;
    Vector3 Position;//캐릭터 위치
    GameObject controllCube;//캐릭터가 선택한 큐브

    private Animator animator;
    private Rigidbody rigid;

    private int hashRun = Animator.StringToHash("runChk");
    private int hashPull = Animator.StringToHash("pullChk");
    private int hashPush = Animator.StringToHash("pushChk");

    //움직이는 속도
    private float horizontalMoveSpeed = 0.3f;
    private float verticalMoveSpeed = 0.3f;
    private float horizontalPushMoveSpeed = 1f;
    private float horizontalPullMoveSpeed = 1f;

    //움직이는 시간 (이걸로 속도 조정)
    private float horizontalMoveTime = 0.1f;//앞 뒤 왼 오
    private float verticalMoveTime = 0.02f;//위 아래
    private float repeatTime = 0.1f; //반복하는 시간

    public float moveSpeed = 10.0f;
    public float jumpPower = 50.0f;

    private bool isJump = false;

    //캐릭터 모션 판정 변수
    public static bool canMove = true;

    public bool can_move_after_fade = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Update is called once per frame
    void Update()
    {
        if (can_move_after_fade) {
            //캐릭터 위치
            MyRound.x = Mathf.Round(gameObject.transform.position.x);
            MyRound.y = Mathf.Round(gameObject.transform.position.y);
            MyRound.z = Mathf.Round(gameObject.transform.position.z);

            //Controll running animation
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)) {
                animator.SetBool("runChk", true);
                animator.Play("running");
            }

            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S)) {
                animator.SetBool("runChk", false);
            }

            //Controll pull animation
            if (Input.GetKeyDown(KeyCode.Mouse0)) {

                Vector3 nol = gameObject.transform.forward.normalized;
                nol.x = Mathf.Round(nol.x);
                nol.y = Mathf.Round(nol.y);
                nol.z = Mathf.Round(nol.z);

                Debug.Log(gameObject.transform.forward.normalized);
                Vector3 front;
                front.x = 0.0F; front.y = 0.0F; front.z = 1.0F;
                Vector3 back;
                back.x = 0.0F; back.y = 0.0F; back.z = -1.0F;
                Vector3 left;
                left.x = -1.0F; left.y = 0.0F; left.z = 0.0F;
                Vector3 right;
                right.x = 1.0F; right.y = 0.0F; right.z = 0.0F;


                if (nol == front) {
                    GameObject.Find("Mana").GetComponent<TestMapSC>().receiveCharacterR(MyRound, front);
                    if (controllCube != null) {
                        GameObject.Find(controllCube.name).GetComponent<cubeG>().pullonoff(front);

                        if (canMove == true) {
                            animator.SetBool("pullChk", true);
                            animator.Play("pull object");
                            InvokeRepeating("moveBack", repeatTime, horizontalMoveTime);//0.2초 단위로 moveup 반복
                            Invoke("CancelmoveBack", horizontalPullMoveSpeed);//2초 뒤에 반복 해제
                        }
                    }
                }
                else if (nol == back) {
                    GameObject.Find("Mana").GetComponent<TestMapSC>().receiveCharacterR(MyRound, back);
                    if (controllCube != null) {
                        GameObject.Find(controllCube.name).GetComponent<cubeG>().pullonoff(back);

                        if (canMove == true) {
                            animator.SetBool("pullChk", true);
                            animator.Play("pull object");
                            InvokeRepeating("moveFront", repeatTime, horizontalMoveTime);//0.2초 단위로 moveup 반복
                            Invoke("CancelmoveFront", horizontalPullMoveSpeed);//2초 뒤에 반복 해제
                        }
                    }
                }
                else if (nol == right) {
                    GameObject.Find("Mana").GetComponent<TestMapSC>().receiveCharacterR(MyRound, right);
                    if (controllCube != null) {
                        GameObject.Find(controllCube.name).GetComponent<cubeG>().pullonoff(right);

                        if (canMove == true) {
                            animator.SetBool("pullChk", true);
                            animator.Play("pull object");
                            InvokeRepeating("moveLeft", repeatTime, horizontalMoveTime);//0.2초 단위로 moveup 반복
                            Invoke("CancelmoveLeft", horizontalPullMoveSpeed);//2초 뒤에 반복 해제
                        }
                    }
                }
                else if (nol == left) {
                    GameObject.Find("Mana").GetComponent<TestMapSC>().receiveCharacterR(MyRound, left);
                    if (controllCube != null) {
                        GameObject.Find(controllCube.name).GetComponent<cubeG>().pullonoff(left);

                        if (canMove == true) {
                            animator.SetBool("pullChk", true);
                            animator.Play("pull object");
                            InvokeRepeating("moveRight", repeatTime, horizontalMoveTime);//0.2초 단위로 moveup 반복
                            Invoke("CancelmoveRight", horizontalPullMoveSpeed);//2초 뒤에 반복 해제
                        }
                    }
                }
            }
            if (Input.GetKeyUp(KeyCode.Mouse0)) {
                animator.SetBool("pullChk", false);
            }

            //controll push animation
            if (Input.GetKeyDown(KeyCode.Mouse1)) {
                Debug.Log(gameObject.transform.forward.normalized);
                Vector3 front;
                front.x = 0.0F; front.y = 0.0F; front.z = 1.0F;
                Vector3 back;
                back.x = 0.0F; back.y = 0.0F; back.z = -1.0F;
                Vector3 left;
                left.x = -1.0F; left.y = 0.0F; left.z = 0.0F;
                Vector3 right;
                right.x = 1.0F; right.y = 0.0F; right.z = 0.0F;

                Vector3 nol = gameObject.transform.forward.normalized;
                nol.x = Mathf.Round(nol.x);
                nol.y = Mathf.Round(nol.y);
                nol.z = Mathf.Round(nol.z);

                if (nol == front) {
                    GameObject.Find("Mana").GetComponent<TestMapSC>().receiveCharacterR(MyRound, front);
                    if (controllCube != null) {
                        GameObject.Find(controllCube.name).GetComponent<cubeG>().pushonoff(front);

                        if (canMove == true) {
                            animator.Play("push object");
                            animator.SetBool("pushChk", true);
                            InvokeRepeating("moveFront", repeatTime, horizontalMoveTime);//0.2초 단위로 moveup 반복
                            Invoke("CancelmoveFront", horizontalPushMoveSpeed);//2초 뒤에 반복 해제
                        }
                    }
                }
                else if (nol == back) {
                    GameObject.Find("Mana").GetComponent<TestMapSC>().receiveCharacterR(MyRound, back);
                    if (controllCube != null) {
                        GameObject.Find(controllCube.name).GetComponent<cubeG>().pushonoff(back);

                        if (canMove == true) {
                            animator.Play("push object");
                            animator.SetBool("pushChk", true);
                            InvokeRepeating("moveBack", repeatTime, horizontalMoveTime);//0.2초 단위로 moveup 반복
                            Invoke("CancelmoveBack", horizontalPushMoveSpeed);//2초 뒤에 반복 해제
                        }
                    }
                }
                else if (nol == right) {
                    GameObject.Find("Mana").GetComponent<TestMapSC>().receiveCharacterR(MyRound, right);
                    if (controllCube != null) {
                        GameObject.Find(controllCube.name).GetComponent<cubeG>().pushonoff(right);

                        if (canMove == true) {
                            animator.Play("push object");
                            animator.SetBool("pushChk", true);
                            InvokeRepeating("moveRight", repeatTime, horizontalMoveTime);//0.2초 단위로 moveup 반복
                            Invoke("CancelmoveRight", horizontalPushMoveSpeed);//2초 뒤에 반복 해제
                        }
                    }
                }
                else if (nol == left) {
                    GameObject.Find("Mana").GetComponent<TestMapSC>().receiveCharacterR(MyRound, left);
                    if (controllCube != null) {
                        GameObject.Find(controllCube.name).GetComponent<cubeG>().pushonoff(left);

                        if (canMove == true) {
                            animator.Play("push object");
                            animator.SetBool("pushChk", true);
                            InvokeRepeating("moveLeft", repeatTime, horizontalMoveTime);//0.2초 단위로 moveup 반복
                            Invoke("CancelmoveLeft", horizontalPushMoveSpeed);//2초 뒤에 반복 해제
                        }
                    }
                }
            }
            if (Input.GetKeyUp(KeyCode.Mouse1)) {
                animator.SetBool("pushChk", false);
            }


            //Controll climbing animation
            if (Input.GetKeyDown(KeyCode.Space)) {
                animator.SetBool("climbChk", true);


                Debug.Log(gameObject.transform.forward.normalized);
                Vector3 front;
                front.x = 0.0F; front.y = 0.0F; front.z = 1.0F;
                Vector3 back;
                back.x = 0.0F; back.y = 0.0F; back.z = -1.0F;
                Vector3 left;
                left.x = -1.0F; left.y = 0.0F; left.z = 0.0F;
                Vector3 right;
                right.x = 1.0F; right.y = 0.0F; right.z = 0.0F;

                Vector3 nol = gameObject.transform.forward.normalized;
                nol.x = Mathf.Round(nol.x);
                nol.y = Mathf.Round(nol.y);
                nol.z = Mathf.Round(nol.z);

                if (nol == front) {
                    GameObject.Find("Mana").GetComponent<TestMapSC>().receiveCharacterR(MyRound, front);
                    if (controllCube != null) {
                        animator.Play("climbing");
                        InvokeRepeating("moveUp", 0.1f, verticalMoveTime);//0.2초 단위로 moveup 반복
                        Invoke("CancelmoveUp", verticalMoveSpeed);//2.5초 뒤에 반복 해제

                        InvokeRepeating("moveFront", 0.1f, 0.02f);//0.2초 단위로 moveup 반복
                        Invoke("CancelmoveFront", horizontalMoveSpeed);//2초 뒤에 반복 해제
                    }
                }
                else if (nol == back) {
                    GameObject.Find("Mana").GetComponent<TestMapSC>().receiveCharacterR(MyRound, back);
                    if (controllCube != null) {
                        animator.Play("climbing");
                        InvokeRepeating("moveUp", 0.1f, verticalMoveTime);//0.2초 단위로 moveup 반복
                        Invoke("CancelmoveUp", verticalMoveSpeed);//2.5초 뒤에 반복 해제

                        InvokeRepeating("moveBack", 0.1f, 0.02f);//0.2초 단위로 moveup 반복
                        Invoke("CancelmoveBack", horizontalMoveSpeed);//2초 뒤에 반복 해제
                    }
                }
                else if (nol == right) {
                    GameObject.Find("Mana").GetComponent<TestMapSC>().receiveCharacterR(MyRound, right);
                    if (controllCube != null) {
                        animator.Play("climbing");
                        InvokeRepeating("moveUp", 0.1f, verticalMoveTime);//0.2초 단위로 moveup 반복
                        Invoke("CancelmoveUp", verticalMoveSpeed);//2.5초 뒤에 반복 해제

                        InvokeRepeating("moveRight", 0.1f, 0.02f);//0.2초 단위로 moveup 반복
                        Invoke("CancelmoveRight", horizontalMoveSpeed);//2초 뒤에 반복 해제
                    }
                }
                else if (nol == left) {
                    GameObject.Find("Mana").GetComponent<TestMapSC>().receiveCharacterR(MyRound, left);
                    if (controllCube != null) {
                        animator.Play("climbing");
                        InvokeRepeating("moveUp", 0.1f, verticalMoveTime);//0.2초 단위로 moveup 반복
                        Invoke("CancelmoveUp", verticalMoveSpeed);//2.5초 뒤에 반복 해제

                        InvokeRepeating("moveLeft", 0.1f, 0.02f);//0.2초 단위로 moveup 반복
                        Invoke("CancelmoveLeft", horizontalMoveSpeed);//2초 뒤에 반복 해제
                    }
                }
            }
            if (Input.GetKeyUp(KeyCode.Space)) {
                animator.SetBool("climbChk", false);
            }

            //맵 밖으로 떨어지면 게임 오버
            if (GameObject.Find("Robot Kyle").transform.position.y < -20) {
                Debug.Log("떨어진다ㅏㅏㅏ");
                GameObject.Find("Sight").GetComponent<move>().cursorMovement();
                character_move.canMove = false;
                GameObject.Find("GameManager").GetComponent<btn_controller>().Stage_fail();
            }
        }
    }

    private void FixedUpdate()
    {
        //jump();
    }


    void jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if(isJump == false) //점프 중이 아니면
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJump = true;
        }
        else
            return;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //바닥에 닿으면 or Cube에 닿으면
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Cube")) {
            //점프가 가능하도록 함
            isJump = false;
        }
    }
    public void receiveControllC(GameObject obt)
    {
        if (obt == null)
        {
            ;
        }
        else
        {
            Debug.Log("조작하려는 위치의 범인 = " + obt.name);
        }
        controllCube = obt;
    }

    //위로 이동
    public void moveUp() {
        Position = gameObject.transform.position;
        Position.y += 1; //위로 이동
        gameObject.GetComponent<Rigidbody>().useGravity = false;//위로 올라가기 위해 중력 비활성화
        transform.position = Vector3.MoveTowards(transform.position, Position, 0.1f);   
    }
    public void CancelmoveUp() {
        //반복 취소 함수
        CancelInvoke("moveUp");
        gameObject.GetComponent<Rigidbody>().useGravity = true;//중력 활성화
        //이상하게 여기도 활성화 해줘야 끝나고 중력이 활성화 되어있음(함수 도는 문제인듯?)
    }

    //오른쪽으로 이동
    public void moveRight()
    {
        Position = gameObject.transform.position;
        Position.x += 1; //오른쪽으로 이동
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        transform.position = Vector3.MoveTowards(transform.position, Position, 0.1f);
    }
    public void CancelmoveRight()
    {
        //반복 취소 함수
        CancelInvoke("moveRight");
        gameObject.GetComponent<Rigidbody>().useGravity = true;//중력 활성화
    }

    //왼쪽으로 이동
    public void moveLeft()
    {
        Position = gameObject.transform.position;
        Position.x -= 1; //왼쪽으로 이동
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        transform.position = Vector3.MoveTowards(transform.position, Position, 0.1f);
    }
    public void CancelmoveLeft()
    {
        //반복 취소 함수
        CancelInvoke("moveLeft");
        gameObject.GetComponent<Rigidbody>().useGravity = true;//중력 활성화
    }

    //앞으로 이동
    public void moveFront()
    {
        Position = gameObject.transform.position;
        Position.z += 1; //앞쪽으로 이동
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        transform.position = Vector3.MoveTowards(transform.position, Position, 0.1f);
    }
    public void CancelmoveFront()
    {
        //반복 취소 함수
        CancelInvoke("moveFront");
        gameObject.GetComponent<Rigidbody>().useGravity = true;//중력 활성화
    }

    //뒤으로 이동
    public void moveBack()
    {
        Position = gameObject.transform.position;
        Position.z -= 1; //뒤쪽으로 이동
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        transform.position = Vector3.MoveTowards(transform.position, Position, 0.1f);
    }
    public void CancelmoveBack()
    {
        //반복 취소 함수
        CancelInvoke("moveBack");
        gameObject.GetComponent<Rigidbody>().useGravity = true;//중력 활성화
    }
}

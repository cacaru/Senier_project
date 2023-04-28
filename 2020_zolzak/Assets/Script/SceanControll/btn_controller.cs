using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class btn_controller : MonoBehaviour
{
    private int pagenumber = 0;
    private string stage;
    public GameObject menuSet;
    public GameObject clear;
    public GameObject gameover;
    public GameObject fade_scenes;
    public UnityEngine.UI.Image fade;
    
    void Start() {
        Time.timeScale = 1;
    }

    void Update() {

        if(Input.GetButtonDown("Cancel")) {
            
        }

        //Option menu setting
        if (Input.GetButtonDown("Cancel")) {

            // 닥치고 움직임 멈춤
            GameObject.Find("Robot Kyle").GetComponent<character_move>().can_move_after_fade = false;
            GameObject.Find("Robot Kyle").GetComponent<fps_movement>().can_move_after_fade = false;

            if (menuSet.activeSelf) {
                GameObject.Find("Sight").GetComponent<move>().cursorContinue();
                GameObject.Find("Sight").GetComponent<move>().can_mouse_move = false;
                Time.timeScale = 1;
                menuSet.SetActive(false);
            }
            else {
                GameObject.Find("Sight").GetComponent<move>().cursorMovement();
                GameObject.Find("Sight").GetComponent<move>().can_mouse_move = true;
                Time.timeScale = 0;
                menuSet.SetActive(true);
                

            }
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            character_move.canMove = false;
        }
    }

    public void MoveLobby() {
        SceneManager.LoadScene("Lobby");
    }

    public void MovestageChoice() {
        SceneManager.LoadScene("StageChoice");
    }

    public void get_start() {
        string val = "start";
        StartCoroutine(delay(val));
    }

    public void MoveNextPage() {
        if (pagenumber == 1)
            pagenumber = 1;
        else
            pagenumber += 1;
        switch (pagenumber) {
            case 0:
                MoveExplain();
                break;
            case 1:
                SceneManager.LoadScene("Explanation2");
                break;
        }
    }

    public void MovePrevPage() {
        if (pagenumber == 0)
            pagenumber = 0;
        else {
            pagenumber -= 1;
        }
        switch (pagenumber) {
            case 0:
                MoveExplain();
                break;
            case 1:
                SceneManager.LoadScene("Explanation2");
                break;
        }
    }

    public void MoveExplain() {
        SceneManager.LoadScene("Explanation");
    }

    public void Quit() {
        //UnityEditor.EditorApplication.isPlaying = false; //play모드를 false로
        Application.Quit();
    }

    public void Retrystage() {
        stage = gameObject.scene.name;
        //Debug.Log(stage);
        switch (stage) {
            case "TestMap":
                SceneManager.LoadScene("TestMap");
                break;
            case "TestMapSH":
                SceneManager.LoadScene("TestMapSH");
                break;
            case "TestMapJY":
                SceneManager.LoadScene("TestMapJY");
                break;
            case "TestMapJH":
                SceneManager.LoadScene("TestMapJH");
                break;
            default:
                Debug.Log("Nothing match");
                break;
        }
        Time.timeScale = 1;
        menuSet.SetActive(false);
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }

    public void Movescene(string scene) {
        stage = scene;
        Debug.Log("Click on " + stage);
        //StartCoroutine(delay(stage));
        
        switch (stage) {
            case "tutorial":
                StartCoroutine(delay(stage));
                break;
            case "TestMapSH":
                SceneManager.LoadScene("TestMapSH");
                break;
            case "TestMapJY":
                SceneManager.LoadScene("TestMapJY");
                break;
            case "TestMapJH":
                SceneManager.LoadScene("TestMapJH");
                break;
            default:
                break;
        }

    }

    public void MoveBack() {
        SceneManager.LoadScene("Lobby");
    }

    public void Continue() {

        // 메뉴 창 닫기
        menuSet.SetActive(false);
        fade_scenes.SetActive(true);

        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        GameObject.Find("Sight").GetComponent<move>().cursorContinue();
        fade.color = new Color(0, 0, 0, 255);

        //캐릭터 움직임 봉쇄
        GameObject.Find("Sight").GetComponent<move>().can_mouse_move = false;
        GameObject.Find("Robot Kyle").GetComponent<character_move>().can_move_after_fade = false;
        GameObject.Find("Robot Kyle").GetComponent<fps_movement>().can_move_after_fade = false;

        // 페이드 인(점차 밝아짐)
        GameObject.Find("BlackScenes").GetComponent<FadeInOut>().fades = 1.0f;
        fade_scenes.GetComponent<FadeInOut>().fade_out_controller = true;
        GameObject.Find("BlackScenes").GetComponent<FadeInOut>().fade_in();

    }

    public void Stage_fail() {
        gameover.SetActive(true);
    }

    IEnumerator delay(string val) {

        // 어두워지기
        fade_scenes.GetComponent<FadeInOut>().image.SetActive(true);
        fade_scenes.GetComponent<FadeInOut>().fade_out_controller = false;
        fade_scenes.GetComponent<FadeInOut>().fade_Out();

        yield return new WaitForSeconds(1.8f);

        switch (val) {
            case "start":
                SceneManager.LoadScene("StageChoice");
                break;
            case "tutorial":
                SceneManager.LoadScene("TestMap");
                break;
            case "TestMapSH":
                SceneManager.LoadScene("TestMapSH");
                break;
            case "TestMapJY":
                SceneManager.LoadScene("TestMapJY");
                break;
            case "TestMapJH":
                SceneManager.LoadScene("TestMapJH");
                break;
        }

    }
}
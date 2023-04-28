using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class btn_controller : MonoBehaviour
{
    public int pagenumber = 0;
    public string stage;
    public GameObject menuSet;
    public GameObject clear;
    public UnityEngine.UI.Image fade;

    void Start() {
        Time.timeScale = 1;
    }

    void Update() {
 
        //Option menu setting
        if (Input.GetButtonDown("Cancel")) {
            if (menuSet.activeSelf) {
                GameObject.Find("Sight").GetComponent<move>().cursorContinue();
                Time.timeScale = 1;
                menuSet.SetActive(false);
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
            }
            else {
                GameObject.Find("Sight").GetComponent<move>().cursorMovement();
                
                Time.timeScale = 0;
                menuSet.SetActive(true);
                Time.fixedDeltaTime = 0.02F * Time.timeScale;

            }
        }
    }

    public void MoveLobby() {
        pagenumber = 0;
        SceneManager.LoadScene("Lobby");
    }

    public void MovestageChoice() {
        SceneManager.LoadScene("StageChoice");
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
        switch (stage) {
            case "tutorial":
                SceneManager.LoadScene("TestMap");
                break;
            default:
                break;
        }
    }

    public void MoveBack() {
        SceneManager.LoadScene("Lobby");
    }

    public void Continue() {
        
        menuSet.SetActive(false);
        
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        GameObject.Find("Sight").GetComponent<move>().cursorContinue();
        fade.color = new Color(0, 0, 0, 255);
        GameObject.Find("BlackScenes").GetComponent<FadeInOut>().fades = 1.0f;
        GameObject.Find("BlackScenes").GetComponent<FadeInOut>().fade_Out();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btn_controller : MonoBehaviour
{
    public int pagenumber = 0;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void MoveLobby() {
        pagenumber = 0;
        SceneManager.LoadScene("Lobby");
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
        UnityEditor.EditorApplication.isPlaying = false; //play모드를 false로

        Application.Quit();
    }
}

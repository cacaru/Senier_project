using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time = 15;
    public Text time_text;


    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        time_text.color = Color.blue;
        coroutine = timer_setting();
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        int integer_time = (int)time;
        time_text.text = integer_time.ToString();
        this.time -= Time.deltaTime;

        if( time < 0) {

            Time.timeScale = 0;
            GameObject.Find("Sight").GetComponent<move>().cursorMovement();
            character_move.canMove = false;
            GameObject.Find("GameManager").GetComponent<btn_controller>().Stage_fail();
            
        }
    }

    private IEnumerator timer_setting() {

        while (true) {

            int val = (int)time;
            
            if( val <= 10)
                time_text.color = Color.red;



            yield return new WaitForSeconds(1);
        }
        
    }
}

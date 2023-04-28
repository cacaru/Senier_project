using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut: MonoBehaviour
{
    public UnityEngine.UI.Image fade;
    public float fades = 1.0f;
    public float time = 0;
    public GameObject image;

    // 다시하기/ 처음 시작 할 때 캐릭어 움직임 막기
    public bool fade_out_controller = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fade_out_controller)
            fade_in();
        else
            fade_Out();
    }

    public void fade_in() {
        time += Time.deltaTime;
        if (fades > 0.0f && time >= 0.1f) {
            fades -= 0.1f;
            fade.color = new Color(0, 0, 0, fades);
            time = 0;
        }
        else if (fades <= 0.0f) {
            time = 0;
            fades = 0;
            fade_out_controller = false;
            image.SetActive(false);
            GameObject.Find("Sight").GetComponent<move>().can_mouse_move = true;
            // 캐릭터 움직임 재개
            GameObject.Find("Robot Kyle").GetComponent<fps_movement>().can_move_after_fade = true;
            GameObject.Find("Robot Kyle").GetComponent<character_move>().can_move_after_fade = true;
        }
    }

    public void fade_Out() {
        time += Time.deltaTime;
        Color temp = fade.color;
        if (fades >= 0.0f && time >= 0.1f) {
            
            fades += 0.1f;
            temp.a += 0.1f;
            fade.color = temp;
            time = 0;
        }
        else if (fades >= 1.0f) {
            time = 0;
        }
        
    }
}

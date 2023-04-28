using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class btn_effect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    void Start() 
    {

    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OnPointerEnter(PointerEventData data) {
        Button tempBtn = gameObject.GetComponent<Button>();

        // 문자열 비교를 위한 변수 자르기
        string str = (string)tempBtn.ToString().Split('(')[0];

        // 크기 크게
        if (str == "btn_quit ") {
            Vector2 resize = new Vector2(250.0f, 250.0f);
            transform.gameObject.GetComponent<RectTransform>().sizeDelta = resize;
        }
        else {
            Vector2 resize = new Vector2(300.0f, 300.0f);
            transform.gameObject.GetComponent<RectTransform>().sizeDelta = resize;
        }
        
        if (str == "btn_start ") {
            Image image = tempBtn.GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>("cube_open") as Sprite;
        }
    }

    public void OnPointerExit(PointerEventData data) {
        Button tempBtn = gameObject.GetComponent<Button>();
        string str = (string)tempBtn.ToString().Split('(')[0];

        Vector2 resize = new Vector2(200.0f, 200.0f);
        transform.gameObject.GetComponent<RectTransform>().sizeDelta = resize;

        if (str == "btn_start ") {
            Image image = tempBtn.GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>("cube") as Sprite;
        }
    }
}

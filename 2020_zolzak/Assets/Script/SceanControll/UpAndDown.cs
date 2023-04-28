using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UpAndDown : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    Vector3 init;
    private bool max = false;
    private bool min = true;
    private bool control = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerExit(PointerEventData data) {
        control = false;
        this.transform.position = init;
    }
    public void OnPointerEnter(PointerEventData data) {
        init = this.transform.position;

        control = true;
        StartCoroutine(move());
    }

    IEnumerator move() {
        Vector3 val = init;
        while (control) {
            Vector3 cur = this.transform.position;

            if( cur.y >= (init.y + 20f)) {
                max = true;
                min = false;
            }
            if( cur.y <= (init.y - 20f)) {
                max = false;
                min = true;
            }
            
            if( min ) {
                val.y += 0.3f;
            }
            if( max ) {
                val.y -= 0.3f;
            }

            this.transform.position = val;
            yield return 0;
        }
        
    }
}

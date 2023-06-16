using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour
{
    public GameObject panel;
    private bool activeNow;
   
    // Start is called before the first frame update
    void Start()
    {
        activeNow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Vector2 poss = Input.GetTouch(0).position;
            RectTransform but = GetComponent<RectTransform>();
            Touch theTouch = Input.GetTouch(0);
            if (theTouch.phase == TouchPhase.Began)
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(but, poss))
                {
                    panel.SetActive(!activeNow);
                    activeNow = !activeNow;
                }
            }
        }
    }
}

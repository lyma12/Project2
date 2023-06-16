using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class ControlForMap : MonoBehaviour
{
    public Camera mainCamera;
    public bool leftButton;
    private RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Vector2 poss = Input.GetTouch(0).position;
            if(RectTransformUtility.RectangleContainsScreenPoint(rectTransform, poss))
            {
                Touch theTouch = Input.GetTouch(0);
                if (theTouch.phase == TouchPhase.Began)
                {

                    float x;
                    if (leftButton) x = 30;
                    else x = -30;
                    Vector3 newPos = new Vector3(x, 0, 0) + mainCamera.transform.position;
                    mainCamera.transform.position = Vector3.Slerp(mainCamera.transform.position, newPos, Time.deltaTime * 500);
                }
            }
        }
    }
}

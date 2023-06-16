using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MonoBehaviour

{

    public GameObject gameObject;
    private RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch theTouch in Input.touches) {
                if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, theTouch.position))
                { 
                    Player player = gameObject.GetComponent<Player>();
                    if (theTouch.phase == TouchPhase.Began ) player.jump();
                }
            }
        }
    }
}
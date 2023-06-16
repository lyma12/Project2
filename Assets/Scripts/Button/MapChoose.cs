using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MapChoose : MonoBehaviour
{
    private Vector3 trans;
    public int groupMap;
    // Start is called before the first frame update
    void Start()
    {
        trans = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary)
            {

                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);


                Collider2D collidingObject = Physics2D.OverlapPoint(new Vector2(touchPosition.x, touchPosition.y));
                if (collidingObject != null && collidingObject.gameObject == gameObject)
                {
                    UnityEngine.Debug.Log("Touch is within the square.");
                    transform.localScale = new Vector3(0.2f, 0.2f, transform.localScale.z);
                }
            }
            else
            {
                transform.localScale = trans;
            }
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MapControl : MonoBehaviour
{
    public GameObject posiPlayer;
    public GameObject anountGame;
    public Transform[] children;
    public GameObject[] setActiveGame;
    private int positionNow;
    // Start is called before the first frame update
    void Start()
    {
        positionNow = posiPlayer.GetComponent<ItemForMap>().group;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            Collider2D collidingObject = Physics2D.OverlapPoint(new Vector2(touchPosition.x, touchPosition.y));
            if(collidingObject != null) { 
                GameObject gameObject = collidingObject.gameObject;
                if (gameObject.GetComponent<ItemForMap>().group != null)
                {
                    int posItem = gameObject.GetComponent<ItemForMap>().group;
                    if (touch.phase == TouchPhase.Began)
                    {
                        gameObject.transform.localScale = new Vector3(0.15f, 0.15f, gameObject.transform.localScale.z);
                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        gameObject.transform.localScale = new Vector3(0.1f, 0.1f, gameObject.transform.localScale.z);
                        StartCoroutine(Delay());
                        if (posItem != positionNow && children.Length >= posItem)
                        {
                            for (int i = 0; i < setActiveGame.Length; i++) setActiveGame[i].SetActive(false);
                            UnityEngine.Debug.Log("Play For pass");
                            anountGame.SetActive(true);
                            posiPlayer.transform.position = children[posItem].position;
                            positionNow = posItem;
                        }
                        else
                        {
                            UnityEngine.Debug.Log("upDate For a minunes");
                        }
                    }
                }
            }
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(6000);
    }
}

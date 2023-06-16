
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Diagnostics;
using System;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.SceneManagement;

public class ChangeButtonImage : MonoBehaviour
{
    private Sprite imageOld;
    public Sprite imageNew;
    private Sprite frameOld;
    public Sprite frameNew;
    public UnityEngine.UI.Image btn;
    public UnityEngine.UI.Image frameBtn;
    public string nameScene;

    private UnityEngine.UI.Image imageComponent;
    private UnityEngine.UI.Image imageFrame;
    private RectTransform rectTransform;
    void Start()
    {
        imageComponent = btn.GetComponent<UnityEngine.UI.Image>();
        imageFrame = frameBtn.GetComponent<UnityEngine.UI.Image>();
        rectTransform = GetComponent<RectTransform>();
        imageOld = imageComponent.sprite;
        frameOld = imageFrame.sprite;
    }
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Vector2 touchPos = Input.GetTouch(0).position;

            if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, touchPos))
            {
                Touch theTouch = Input.GetTouch(0);
                if(theTouch.phase == TouchPhase.Began || theTouch.phase == TouchPhase.Stationary)
                {
                    imageFrame.sprite = frameNew;
                    imageComponent.sprite = imageNew;

                }
                else
                {
                    imageFrame.sprite = frameOld;
                    imageComponent.sprite = imageOld;
                }
                if(theTouch.phase == TouchPhase.Ended)
                {
                    SceneManager.LoadScene(nameScene);
                }
                
            }
        }
    }
}
        


   

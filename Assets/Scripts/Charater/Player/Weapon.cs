﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float offset;
    public RectTransform rectTransform;

    public GameObject projectile;
    public GameObject shotEffect;
    public Transform shotPoint;
  

    private float timeBtwShots;
    public float startTimeBtwShots;

    private void Update()
    {
        // Handles the weapon rotation
        if (Input.touchCount > 0)
        {
            foreach (Touch theTouch in Input.touches)
            {
            if (!RectTransformUtility.RectangleContainsScreenPoint(rectTransform, theTouch.position))
                {
            Vector3 difference = Camera.main.ScreenToWorldPoint(theTouch.position) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

            if (timeBtwShots <= 0)
            {
                
                    Instantiate(shotEffect, shotPoint.position, Quaternion.identity);
                    Instantiate(projectile, shotPoint.position, transform.rotation);
                    timeBtwShots = startTimeBtwShots;
                
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
                }
            }
        }
       
    }
}

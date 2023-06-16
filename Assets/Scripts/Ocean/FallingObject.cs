using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private Vector2 movementDirection;
    public Rigidbody2D rigidbody2D;
    [SerializeField]
    private float forceAmount;
    private float timeElapsed;
    private bool isMoving = false;
    void Start()
    {
        rigidbody2D.velocity = Vector3.down * forceAmount;
    }

    void Update() { 
        
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        timeElapsed += Time.deltaTime;

     
    }
}

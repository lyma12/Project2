using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public abstract class Monster : Charater
{
    public float viewArea;
    private Rigidbody2D rb;
    protected bool chase = true;
    private GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision2D)
    {
        
        GameObject gameObject = collision2D.gameObject;
        if (gameObject.CompareTag("Player"))
        {
            chase = false;
            playerObject = gameObject;
            attack();
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision2D)
    {
        chase = true;
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("idle");
        anim.ResetTrigger("run");
    }
    
    protected virtual void OnTriggerStay2D(Collider2D collider2D)
    {
        Animator anim = GetComponent<Animator>();
            GameObject gameObject = collider2D.gameObject;
            // kiem tra co phai charater khong
            if (gameObject.CompareTag("Player") && chase)
            {
            anim.SetTrigger("run");
            // neu phai monster se duoi theo Player
            //float distance = Vector2.Distance(transform.position, gameObject.transform.position);
            //Vector2 direction = gameObject.transform.position - this.transform.position;
            
            this.transform.position = Vector2.MoveTowards(this.transform.position, gameObject.transform.position, speed * Time.deltaTime);
            }
        
    }
    public GameObject getPlayerObject()
    {
        return playerObject;
    }

}

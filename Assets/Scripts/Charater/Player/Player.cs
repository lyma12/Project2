using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Player : Charater
{
    private Animator anim;
    public float maxEnergy;
    public float currentEnergy;
    public float jumpHeight;
    private Rigidbody2D rb;
    private bool isJump = false;
    private Vector2 moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        setCurrentHealth();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*

            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            if (rb.velocity.x > 0)
            {
                animator.SetFloat("R", 1);
            }
            else if (rb.velocity.x < 0)
            {
                animator.SetFloat("R", 6);
            }
            float move = rb.velocity.x == 0 ? rb.velocity.y : rb.velocity.x;
            animator.SetFloat("speedMove", Mathf.Abs(move));
        */

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        moveVelocity = moveInput * speed;

        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isRunning", true);
            UnityEngine.Debug.Log("run");
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    public void recoverEnergy()
    {
        
    }
    public void jump()
    {
        if (!isJump)
        {
            isJump = true;
            UnityEngine.Debug.Log("Jump");
            //animator.SetTrigger("Jump");
        }
        isJump = false;

    }
    public void recoverHealth()
    {

    } 
    public override void attack()
    {

    }
}

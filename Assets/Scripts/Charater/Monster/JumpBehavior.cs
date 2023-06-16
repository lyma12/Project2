using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class JumpBehavior : StateMachineBehaviour {


    private float timer;
    private GameObject gamer;
    public float minTime;
    public float maxTime;

    private Transform playerPos;
    public float speed;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
         gamer = GameObject.FindGameObjectWithTag("Player");
        /*
         if (gamer != null) {
             playerPos = gamer.GetComponent<Transform>();

         }
         timer = UnityEngine.Random.Range(minTime, maxTime);*/
        if (animator.GetBool("run") && gamer != null)
        {
            playerPos = gamer.GetComponent<Transform>();
        }
        timer = UnityEngine.Random.Range(minTime, maxTime);
    }

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (timer <= 0 || gamer == null)
        {
            animator.SetTrigger("idle");
        }
        else {
            timer -= Time.deltaTime;
        }
        if (gamer != null && playerPos != null)
        {
            Vector2 target = new Vector2(playerPos.position.x, animator.transform.position.y);
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPos.position, speed * Time.deltaTime);
        }
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        gamer = null;
        playerPos = null;
        animator.SetTrigger("idle");
        animator.ResetTrigger("run");

	}

}

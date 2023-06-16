using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : Monster {
    private Animator anim;
    public bool isDead;

    private void Start()
    {
        anim = GetComponent<Animator>();
        setCurrentHealth();
        setUpHealthBar();
    }

    private void Update()
    {
        if (getCurrentHealth() <= maxHealth/2) {
            anim.SetTrigger("stageTwo");
        }

        // give the player some time to recover before taking more damage !
        if (speed > 0) {
            speed -= Time.deltaTime;
        }
    }

    public override void attack()
    {
        
        if (getPlayerObject() != null)
        {
            var player = getPlayerObject().GetComponent<Player>();
            if (player.getCurrentHealth() >= 0)
            {
                player.TakeDamage(attackDamage);
                StartCoroutine(Delay());
            }
            else
            {
                player.Die();
            }

        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(this.attackSpeed * 600);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        setCurrentHealth();
    }

    // Update is called once per frame
    public override void attack()
    {
        
        if(getPlayerObject() != null)
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
        yield return new WaitForSeconds(this.attackSpeed*600);  
    }
}

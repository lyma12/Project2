using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSoftBody : MonoBehaviour
{
    public Monster mainBody;
    private void OnCollisionStay2D(Collision2D collision2D)
    {
        GameObject gameObject = collision2D.gameObject;
        if (gameObject.CompareTag("Player"))
        {
            
            Player player = gameObject.GetComponent<Player>();
            if (player != null)
            {
                if (player.getCurrentHealth() >= 0)
                {
               
                    player.TakeDamage(mainBody.attackDamage*2);
                    StartCoroutine(Delay());
                }
                else
                {
                    player.Die();
                }
            }
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(mainBody.attackSpeed * 600);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftMonster : Monster
{
    [SerializeField]
    private float offset;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private GameObject shotEffect;
    [SerializeField]
    private Transform shotPoint;

    private float timeBtwShots = 0;
    [SerializeField]
    private float startTimeBtwShots;
    private GameObject PlayerObject;
    void Start()
    {
        setCurrentHealth();
    }
    protected override void OnTriggerStay2D(Collider2D collider2D)
    {
        Animator anim = GetComponent<Animator>();
        PlayerObject = collider2D.gameObject;
        // kiem tra co phai charater khong
        if (gameObject.CompareTag("Player") && chase)
        {

            anim.SetTrigger("run");
            // neu phai monster se duoi theo Player
            //float distance = Vector2.Distance(transform.position, gameObject.transform.position);
            //Vector2 direction = gameObject.transform.position - this.transform.position;

            this.transform.position = Vector2.MoveTowards(this.transform.position, gameObject.transform.position, speed * Time.deltaTime);
            attack();
        }

    }
    // Update is called once per frame
    public override void attack()
    {
            var player = PlayerObject.GetComponent<Player>();
            if (player != null)
            {
            UnityEngine.Debug.Log("pug");

            if (timeBtwShots <= 0)
                {
                    UnityEngine.Debug.Log("pug");
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


    IEnumerator Delay()
    {
        yield return new WaitForSeconds(this.attackSpeed * 600);
    }
}

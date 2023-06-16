using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private float speedFollow = 1.2f;
    private float yOffset = 1;
    private float xOffset = 1;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {

            target = player.GetComponent<Transform>();
         
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 newPos = new Vector3(target.position.x + xOffset, target.position.y + yOffset, -10f);
            this.transform.position = Vector3.Slerp(this.transform.position, newPos, speedFollow * Time.deltaTime);
        }
    }
}

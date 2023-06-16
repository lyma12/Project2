using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public bool start = true;
    private void OnCollisionStay2D(Collision2D[] collision2D)
    {
        foreach (var col in collision2D)
        {
            GameObject gameObject = col.gameObject;
            if (gameObject.CompareTag("Monster") && start)
            {
                Destroy(gameObject);
            }
        }
        start = false;
    }
}

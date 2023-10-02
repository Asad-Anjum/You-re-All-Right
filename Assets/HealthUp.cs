using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            col.GetComponent<Player>().health = 4;
            col.GetComponent<Player>().anim.SetInteger("health", col.GetComponent<Player>().health);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnDetection2 : MonoBehaviour
{
    public bool turn = true;
    public Collider2D col;

    void Start()
    {
        col = this.GetComponent<Collider2D>();
    }


    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Wall")
        {
            turn = false;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Wall")
        {
            turn = true;
        }
    }

}

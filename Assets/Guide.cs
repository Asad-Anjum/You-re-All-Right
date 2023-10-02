using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    public Transform[] Positions;
    public float guideSpeed;
    
    bool reached = false;
    int nextInd;
    Transform nextPos;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = Positions[0];
    }

    // Update is called once per frame
    void Update()
    {
        MoveGuide();
        if(nextInd >= Positions.Length)
        Destroy(gameObject);
    }

    void MoveGuide()
    {
        if(transform.position == nextPos.position && reached)
        {
            reached = false;
            nextInd++;
            nextPos = Positions[nextInd];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos.position, guideSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            reached = true;
        }
    }
}

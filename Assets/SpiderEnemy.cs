using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemy : MonoBehaviour
{
    public float patrolDistance = 2.0f;  // The max distance from the starting position.
    public float patrolSpeed = 2.0f;     // Movement speed.

    private Vector3 startPos;
    private bool movingRight = true;
    private Vector3 offset; // To store the distance from the startPos

    public Transform startPosMarker;  // Drag the corresponding startPos marker here in the editor.


    void Start()
    {
        startPos = startPosMarker.position;
        

    }

    void Update()
    {
        MoveEnemy();
        if (Rotate.hasCompletedRotation)
        {
            startPos = startPosMarker.position;
        }
    }

    void MoveEnemy()
    {
        if (movingRight)
        {
            // Move to the right in local space.
            transform.Translate(Vector2.right * patrolSpeed * Time.deltaTime, Space.Self);
            
            // Check if it has moved past the allowed distance.
            if (Vector3.Distance(transform.position, startPos) > patrolDistance)
            {
                movingRight = false;
            }
        }
        else
        {
            // Move to the left in local space.
            transform.Translate(Vector2.left * patrolSpeed * Time.deltaTime, Space.Self);
            
            // Check if it has moved past the starting position.
            //if (Vector3.Distance(transform.position, startPos) < 0.01f)
            if (Vector3.Distance(transform.position, startPos) > patrolDistance)
            {
                movingRight = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Check if the colliding object is the player.
        if (col.gameObject.CompareTag("Player"))
        {
            // Get the player's script to access its variables and methods.
            JumpLine jumpScript = col.gameObject.GetComponent<JumpLine>();
            Player playerScript = col.gameObject.GetComponent<Player>();

            if (jumpScript.moving)  // Player is jumping.
            {
               // Destroy(gameObject);  // Destroy the enemy.
            }
            else  // Player is not jumping.
            {
                playerScript.TakeDamage();  // Player takes damage.
                // If you don't have a TakeDamage function yet, you'll need to create it.
            }
        }
    }

}

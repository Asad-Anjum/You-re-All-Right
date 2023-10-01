using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        // Check if the colliding object is the player.
        if (col.gameObject.CompareTag("Player"))
        {
            // Get the player's script to access its variables and methods.
            Player playerScript = col.gameObject.GetComponent<Player>();
            playerScript.TakeDamage();  // Player takes damage.
            // If you don't have a TakeDamage function yet, you'll need to create it.
            
        }
    }
}

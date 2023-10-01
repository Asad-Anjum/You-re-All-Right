using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;  // Assuming the player has 100 health points.
    public bool hasKey = false;

    public void TakeDamage(int damageAmount = 10)  // Default damage amount is 10.
    {
        health -= damageAmount;

        // Optional: You can add feedback, e.g., change player color, play a sound, etc.

        if (health <= 0)
        {
            // Handle player's death. 
            // e.g., restart the level, show a game over screen, etc.
        }
    }
    }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Transform player;
    public float baseFollowSpeed = 2f;  // This is the basic speed.
    public float pickUpRange = 2f;      // When the key starts following.
    public float stopDistance = 0.5f;   // When the key should stop.

    private bool isFollowing = false;

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < pickUpRange)
        {
            isFollowing = true;
        }

        if (isFollowing && distanceToPlayer > stopDistance) // Modified this line to check stop distance.
        {
            // Scaling speed with distance.
            float scaledSpeed = baseFollowSpeed * distanceToPlayer;

            transform.position = Vector2.MoveTowards(transform.position, player.position, scaledSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isFollowing = true;
            Player playerScript = other.gameObject.GetComponent<Player>();
            playerScript.hasKey = true;
            // Optionally, you can disable the collider so it doesn't keep triggering other things:
            GetComponent<Collider2D>().enabled = false;
        }
    }
}


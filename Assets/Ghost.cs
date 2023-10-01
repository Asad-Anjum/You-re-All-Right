using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ghost : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Check if the colliding object is the player.
        if (col.gameObject.CompareTag("Player"))
        {
            Player playerScript = col.gameObject.GetComponent<Player>();
            if (playerScript.hasKey == true) {
                LoadNextScene();
            }
        }
    }

    void LoadNextScene()
    {
        // Get the index of the current scene and add one to move to the next scene.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings; // Using modulo to loop back to the first scene if you're on the last scene.

        SceneManager.LoadScene(nextSceneIndex);
    }
}

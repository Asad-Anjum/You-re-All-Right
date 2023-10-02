using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScreenController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1"); // Replace "MainGame" with the name of your main game scene
    }
}
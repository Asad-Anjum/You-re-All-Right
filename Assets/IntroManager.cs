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

    public void BackToIntro()
    {
        SceneManager.LoadScene("Intro"); // Replace "MainGame" with the name of your main game scene
    }

    public void KnownIssues()
    {
        SceneManager.LoadScene("KnownIssues"); // Replace "MainGame" with the name of your main game scene
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public int health = 4;  
    public bool hasKey = false;
    public Animator anim;
    SpriteRenderer sr;
    private JumpLine jl;
    public Rotate rot;
    public TextMeshProUGUI healthDisplay;
    public float displayDuration = 1.0f;  
    public AudioSource aud;

    void Start()
    {
        healthDisplay.enabled = false;
        anim = GetComponent<Animator>();
        anim.SetInteger("health", health);
        sr = this.GetComponent<SpriteRenderer>();
        jl = this.GetComponent<JumpLine>();
        healthDisplay.text = health.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
        // Debug.Log(health);
    }

    public void TakeDamage(int damageAmount = 1)  
    {
        aud.Play();
        health -= damageAmount;
        anim.SetInteger("health", health);
        StartCoroutine(DamageFlash());

        healthDisplay.text = health.ToString();
        healthDisplay.enabled = true; 
        StartCoroutine(HideHealthDisplayAfterDelay());

        
        if(!rot.turn && !rot.firstAfterTurn)
        {
            transform.position = jl.oldPosition;
        }
        

        if(jl.moving && !rot.turn) 
        {
            jl.roof = !jl.roof;
            jl.ground = !jl.ground;
        }



        

        // Optional: You can add feedback, e.g., change player color, play a sound, etc.

        if (health <= 0)
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public IEnumerator DamageFlash()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
        yield return new WaitForSeconds(0.1f);

    }

    IEnumerator HideHealthDisplayAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);
        healthDisplay.enabled = false;  // Hide the health display
    }


    }

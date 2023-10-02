using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float fadeDuration = 1.0f;
    public static bool firstJumpDone = false;
    public static bool firstResetDone = false;
    public static bool firstKillDone = false;
    public string doneCriteria = "none";

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (doneCriteria == "jump")
        {
            if (firstJumpDone) {
               fadeDestroy();
            }
        }
        else if (doneCriteria == "reset")
        {
            if (firstResetDone) {
                fadeDestroy();
            }
        } else if (doneCriteria == "kill") {
            if (firstKillDone) {
                fadeDestroy();
            }
        }
    }

    void fadeDestroy() {
        Color currentColor = spriteRenderer.color;
        float newAlpha = currentColor.a - fadeDuration * Time.deltaTime;

        if (newAlpha <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            spriteRenderer.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
        }
    }
}

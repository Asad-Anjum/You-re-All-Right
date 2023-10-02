using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpLine : MonoBehaviour
{
    Vector3 jumpLine;
    Rigidbody2D rb;
    LineRenderer lr;
    public float lineLength;
    Vector3 mousePos;
    Vector3 invMousePos;
    Vector3 invTran;
    public Vector2 distance;
    public float speed;
    Vector2 target;
    Collider2D col;
    bool pause = true;
    SpriteRenderer sr;
    public bool ground = false;
    public bool roof = true;
    Quaternion endRotation;
    public float rotationSpeed = 10f;

    public TurnDetection td;
    public TurnDetection2 td2;
    public TurnDetection3 td3;
    private bool move = false;

    public bool moving = false;
    private Animator anim;
    public bool inRange = false;
    public bool upwards = false;

    public Rotate rot;
    int counter = 0;
    public Vector3 oldPosition;
    public tutorial jumpTutorial;
    public tutorial resetTutorial;
    



    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        lr = this.GetComponent<LineRenderer>();
        col = this.GetComponent<Collider2D>();
        sr = this.GetComponent<SpriteRenderer>();
        td = this.GetComponentInChildren<TurnDetection>();
        td2 = this.GetComponentInChildren<TurnDetection2>();
        td3 = this.GetComponentInChildren<TurnDetection3>();
        target.x = transform.position.x;
        target.y = transform.position.y;
        endRotation = transform.rotation;
        lr.enabled = true;
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        CalculateJumpVector();
        DrawLine();
        
        if(counter<3) counter++;
        
        
        
        if(Input.GetMouseButtonDown(0) && !moving && !rot.turn)
        {
            jumpTutorial.firstJumpDone = true;
            move = true;
            rot.firstAfterTurn = false;
            if(distance.y > 0) upwards = true;
            else upwards = false;
        }

        if(!moving && Input.GetMouseButtonDown(1) && !rot.turn && !rot.firstAfterTurn)
        {
            resetTutorial.firstResetDone = true;
            transform.position = oldPosition;
            // roof = !roof;
            // ground = !ground;
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            roof = !roof;
            ground = !ground;
        }

        
        if(roof)
        {
            sr.flipY = true;
        }
        else sr.flipY = false;
        


        if(pause && counter > 2){
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            pause = false;
            lr.enabled = true;
            moving = false;
            roof = !roof;
            ground = !ground;
            Debug.Log("Pauses");
        }

        if(moving)
        {
            anim.SetBool("jumping", true);
        }
        else
        {
            anim.SetBool("jumping", false);
        }

 



        
    }

    void FixedUpdate()
    {
        if(move)
        {
            oldPosition = transform.position;
            moving = true;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.AddForce(jumpLine * speed);
            lr.enabled = false;

            move = false;
        }


            
    }

    void CalculateJumpVector()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        distance = mousePos - this.transform.position;

            if(ground){

                if(distance.x < 0) distance.x = 0;
                    if((distance.y/distance.x) < 1)
                    {
                    distance.x = 1;
                    distance.y = 1f;
                    }
                }


            if(roof){

                if(distance.x < 0) {
                    distance.x = 0;
                    distance.y = -1f;
                }
                    if(((distance.y/distance.x) > -1f && distance.y < 0) || (distance.x > 0 && distance.y > 0)){
                        distance.x = 1f;
                        distance.y = -1f;
                    }
                }

        jumpLine = distance.normalized * lineLength;
    }

    void DrawLine()
    {
        lr.positionCount = 2;
        lr.SetPosition(0,Vector3.zero);
        lr.SetPosition(1, jumpLine);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Wall")
        {
            pause = true;
        }
    }

}

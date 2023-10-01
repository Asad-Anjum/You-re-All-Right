using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public bool turn = false;
    float target;

    public TurnDetection td;
    public TurnDetection2 td2;
    public TurnDetection3 td3;
    public JumpLine jl;
    float mult = -1f;

    private bool wasTurning = false; // This tracks if the map was turning in the last frame
    public static bool hasCompletedRotation = false;
    private bool processedRotation = false;  // To check if we've processed the completed rotation.


    // Update is called once per frame
    void Update()
    {
        if(turn)
        {
            if(jl.upwards){
                if(transform.eulerAngles.z <= target || (target == 0 && transform.eulerAngles.z > 90f)){
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, target);
                    turn = false;
                    td.col.enabled = true;
                }
            }
            else
            {
                if((transform.eulerAngles.z >= target && target !=0) || (target == 0 && transform.eulerAngles.z < 90f)){
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, target);
                    turn = false;
                    td.col.enabled = true;
                }
            }
            
        }

        // Debug.Log(transform.eulerAngles.z);

        // if(jl.roof)
        // {
        //     if(transform.eulerAngles.z >= target || (target == 0 && transform.eulerAngles.z < 90f)){
        //         transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, target);
        //         turn = false;
        //         td.col.enabled = true;
        //     }
        // }




        if(td.turn == true){ //&& td2.turn == true && td3.turn == true){
            turn = true;
            target = targetAngle(transform.eulerAngles.z);
            td.turn = false;
            td.col.enabled = false;
            jl.roof = !jl.roof;
            jl.ground = !jl.ground;
        }


        
        if(turn){
            if(jl.upwards)
                transform.RotateAround(player.transform.position, Vector3.forward, -speed * Time.deltaTime);
            else
                transform.RotateAround(player.transform.position, Vector3.forward, speed * Time.deltaTime);
        }

        if (!turn && wasTurning) // When the rotation has just completed
        {
            if (!processedRotation)
            {
                hasCompletedRotation = true;
                processedRotation = true;
            }
        }
        else
        {
            hasCompletedRotation = false;
            processedRotation = false;
        }

        wasTurning = turn;


        
    }


    float targetAngle(float z)
    {
        if(jl.upwards)
        {
            if(z == 0f) return 270f;
            else if(z == 270f) return 180f;
            else if(z == 180f) return 90f;
            else return 0f;
        }
        else
        {
            if(z == 0f) return 90f;
            else if(z == 90f) return 180f;
            else if(z == 180f) return 270f;
            else return 0f;
        }

    }
}

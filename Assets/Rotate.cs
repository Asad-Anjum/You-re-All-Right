using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameObject player;
    public float speed;
    bool turn = false;
    float target;

    public TurnDetection td;
    public TurnDetection2 td2;
    public TurnDetection3 td3;
    public JumpLine jl;
    float mult = -1f;

    // Update is called once per frame
    void Update()
    {
        // if(jl.ground)
        // {
            if(transform.eulerAngles.z <= target || (target == 0 && transform.eulerAngles.z > 90f)){
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, target);
                turn = false;
                td.col.enabled = true;
            }
        //}

        // if(jl.roof)
        // {
        //     if(transform.eulerAngles.z >= target || (target == 0 && transform.eulerAngles.z < 90f)){
        //         transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, target);
        //         turn = false;
        //         td.col.enabled = true;
        //     }
        // }
        if(Input.GetMouseButtonDown(1)){
            turn = true;
            target = targetAngle(transform.eulerAngles.z);
        }



        if(td.turn == true){ //&& td2.turn == true && td3.turn == true){
            turn = true;
            target = targetAngle(transform.eulerAngles.z);
            td.turn = false;
            td.col.enabled = false;
            jl.roof = !jl.roof;
            jl.ground = !jl.ground;
            jl.sideways = !jl.sideways;
        }


        
        if(turn){
            // if(!jl.ground && first){
            //     transform.RotateAround(player.transform.position, Vector3.forward, -speed * Time.deltaTime);
            //     first = false;
            // }
            // else if(jl.ground && !first)  transform.RotateAround(player.transform.position, Vector3.forward, -speed * Time.deltaTime);
            // else if(jl.roof && first){
            //     Debug.Log("Here");
            //     transform.RotateAround(player.transform.position, Vector3.forward, speed * Time.deltaTime);
            //     first = false;
            // }
            // else if (!jl.roof && !first){
            //     Debug.Log("No Here");
            //     transform.RotateAround(player.transform.position, Vector3.forward, speed * Time.deltaTime);
            // }

           
            

                transform.RotateAround(player.transform.position, Vector3.forward, -1 * speed * Time.deltaTime);
        }


        
    }


    float targetAngle(float z)
    {

            if(z == 0f) return 270f;
            else if(z == 270f) return 180f;
            else if(z == 180f) return 90f;
            else return 0f;
    }
}

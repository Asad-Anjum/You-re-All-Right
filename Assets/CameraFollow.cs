using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 2f;
    float yOffset = 1f;
    public Transform target;
    private Quaternion _targetRot;
    public float rotationSpeed = 10f;
    Quaternion endRotation;
    public JumpLine jl;

    void Start()
    {
        endRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(!jl.ground)
        {
            yOffset = -1f;
        }
        else
        {
            yOffset = 1f;
        }

    }

    void LateUpdate()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}

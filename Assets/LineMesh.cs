using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMesh : MonoBehaviour
{
    public LineRenderer lr;
    public GameObject player;
    public JumpLine jl;
    // Start is called before the first frame update
    void Start()
    {
        GenerateCircleCollider();
        // Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider2D>());
    }

    public void GenerateCircleCollider()
    {
        MeshCollider collider = GetComponent<MeshCollider>();

        if(collider == null)
        {
            collider = gameObject.AddComponent<MeshCollider>();
        }

        Mesh mesh = new Mesh();
        lr.BakeMesh(mesh);
        collider.sharedMesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {
        GenerateCircleCollider();
    }

    void OnCollisionStay(Collision col)
    {
        Debug.Log(col.gameObject.tag);
        if(col.gameObject.tag == "Wall")
        {
            jl.inRange = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if(col.gameObject.tag == "Wall")
        {
            jl.inRange = false;
        }
    }
}

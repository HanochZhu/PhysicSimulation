using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// test physic
// simulator parabola generate by free falling object
public class TestParabola : MonoBehaviour
{
    public bool UseGravity = true;

    public float GravityFactor = 9.8f;

    public Vector3 InitVelocity = new Vector3(1,1,1);

    public float velocitySpeed = 10f;

    private Vector3 curVelocity;

    private float mass = 1f;


    private void Awake()
    {
        curVelocity = InitVelocity;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    // physix implement
    private void FixedUpdate()
    {
        Vector3 accelerate = Vector3.down * GravityFactor / mass;
        if (UseGravity)
        {
            // time.deltatime update in fixupdate loop
            float dt = Time.deltaTime;
            Vector3 nextVelocity = GetNextVelocity(curVelocity, accelerate, dt);
            //pos
            Vector3 deltaPos = curVelocity * dt;

            Vector3 nextPos = transform.position + deltaPos;
            transform.position = nextPos;

            curVelocity = nextVelocity;
        }
    }

    public Vector3 GetNextPosition(Vector3 force,ref Vector3 curVelocity,float dt, Vector3 curPosition)
    {
        Vector3 accelerate = force / mass;

        Vector3 nextVelocity = GetNextVelocity(curVelocity, accelerate, dt);

        Vector3 deltaPos = curVelocity * dt;

        Vector3 nextPos = transform.position + deltaPos;

        curVelocity = nextVelocity;

        return nextPos;
    }


    //next velocity under a extra force
    private static Vector3 GetNextVelocity(Vector3 v0,Vector3 a,float dt)
    {
        return v0 + a * dt;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Physic;

public class TestRope : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform anchor;

    public Vector3 gravityForce = new Vector3(0, -9.8f,.0f);

    private Vector3 curVelocity = Vector3.zero;

    public float mass = 1;

    private float _initLenghtOfRope = 0.0f;

    private Vector3 startPos;
    private Vector3 curPos;
    private Vector3 curPos_t; // t - dt

    void Start()
    {
        _initLenghtOfRope = Vector3.Distance(anchor.position , transform.position);
        startPos = transform.localPosition;
        curPos = startPos;
        curPos_t = startPos;
    }

    private void Update()
    {
        //transform.position = curPos;
    }


    private void FixedUpdate()
    {
        if (anchor == null)
        {
            return;
        }
        float deltaTime = Time.fixedDeltaTime;

        // _   _   _  _   _   _ 
        // c = a + b, b = c - a
        Vector3 resultant0 = GetForce(anchor.position, curPos, gravityForce);
        //Vector3 nextPos = velocityVerletXdt(curPos, curVelocity, resultant0, mass, deltaTime);
        //Vector3 resultant1 = GetForce(anchor.position, nextPos, gravityForce);
        //Vector3 nextVelocity = velocityVerletvdt(curVelocity, resultant1, resultant0, mass, deltaTime);
        //Debug.DrawLine(transform.position, curPos + curVelocity.normalized * 10, Color.red);
        //Vector3 nextPos = PhysicUtils.GetNextPosition(resultant0, ref curVelocity, deltaTime, transform.position, mass);
        print(curPos_t);
        print(curPos);
        Vector3 accelerate = resultant0 / mass;
        print(accelerate);
        Vector3 nextPos = GetNextPosition(curPos_t, curPos, ref curVelocity, accelerate, deltaTime);
        // recorrect
        // __   _   _
        // ab = b - a
        curPos_t = curPos;
        Vector3 deltaPos = nextPos - curPos;
        float angle = deltaPos.magnitude / 5f;

        print(nextPos);

        nextPos = curPos.RotationAroundZ(anchor.localPosition, angle);
        print(nextPos);

        //Vector3 dirtoAnchor = nextPos - anchor.position;

        //if (dirtoAnchor.magnitude > _initLenghtOfRope)
        //{
        //    nextPos = anchor.position + dirtoAnchor.normalized * _initLenghtOfRope;
        //}
        // curVelocity = nextVelocity;
        transform.position = nextPos;
        curPos = nextPos;
    }

    public Vector3 GetForce(Vector3 anchorPos,Vector3 localPos,Vector3 extraForce)
    {
        Vector3 d = localPos - anchorPos;
        d.Normalize();
        Vector3 fdot = Vector3.Dot(extraForce, d) * d;
        return extraForce - fdot;
    }

    private Vector3 GetNextPosition(Vector3 post_dt, Vector3 post,ref Vector3 velocityt, Vector3 a, float deltaTime)
    {

        Vector3 posJ0deltat = posdeltat(post, post_dt, a, deltaTime);

        //iteratorVelocity(ref posJ0deltat, post, ref velocityt, deltaTime, 100);

        return posJ0deltat;
    }

    // formula 1
    private Vector3 posdeltat(Vector3 post_dt, Vector3 post,Vector3 a,float deltaTime)
    {
        return 2 * post - post_dt + a * deltaTime * deltaTime;
    }

    // formula 2
    private Vector3 velocitydeltat(Vector3 post, Vector3 post_dt, Vector3 a, float deltaTime)
    {
        return 2 * post - post_dt + a * deltaTime;
    }

    // formula 3
    private void iteratorVelocity(ref Vector3 posJ0deltat,Vector3 post,ref Vector3 velocityt,float deltaTime,float times)
    {
        Vector3 velocityJ1Deltat = (posJ0deltat - post) / deltaTime;
        Vector3 posJ1Deltat = post + (velocityt + velocityJ1Deltat) * deltaTime / 2f;
        if (Vector3.Distance(posJ1Deltat,posJ0deltat) > 0.001f || times > 0)
        {
            iteratorVelocity(ref posJ1Deltat, post, ref velocityt, deltaTime, --times);
        }
    }

    private Vector3 velocitytVerlet(Vector3 posAddDeltaT,Vector3 pos_dT,float deltaTime)
    {
        return (posAddDeltaT - pos_dT) / (2f * deltaTime);
    }

    public Vector3 velocityVerletXdt(Vector3 xt, Vector3 vt,Vector3 forcet,float mass,float delta)
    {
        Vector3 xtdt = xt + vt * delta + forcet / (2 * mass) * delta * delta;

        return xtdt;
    }

    public Vector3 velocityVerletvdt(Vector3 vt, Vector3 forcedt,Vector3 forcet, float mass, float delta)
    {
        Vector3 vtdt = vt + (forcedt + forcet) / (2 * mass) * delta;
        // Debug.Log("kinetic" + GetKineticEnergy(mass,vtdt));
        return vtdt;
    }

    public float GetKineticEnergy(float mass, Vector3 velocity)
    {
        float v = velocity.magnitude;
        return mass * v * v / 2f;
    }
}

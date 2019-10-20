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

    void Start()
    {
        _initLenghtOfRope = Vector3.Distance(anchor.position , transform.position);
    }


    private void FixedUpdate()
    {
        if (anchor == null)
        {
            return;
        }
        float deltaTime = Time.deltaTime;

        Vector3 dirtoAnchor = anchor.position - transform.position;
        // _   _   _  _   _   _  
        // c = a + b, b = c - a
        Vector3 resultant = gravityForce - Vector3.Dot(dirtoAnchor, gravityForce) * dirtoAnchor.normalized;

        Vector3 nextPos = PhysicUtils.GetNextPosition(resultant, ref curVelocity, deltaTime, transform.position, mass);

        // recorrect
        // __   _   _
        // ab = b - a
        dirtoAnchor = nextPos - anchor.position;

        if (dirtoAnchor.magnitude > _initLenghtOfRope)
        {
            nextPos = anchor.position + dirtoAnchor.normalized * _initLenghtOfRope;
        }

        transform.position = nextPos;
    }
}

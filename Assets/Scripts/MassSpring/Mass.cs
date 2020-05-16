using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mass:MonoBehaviour
{
    public float MassValue = 1;// kg

    public bool isPined;

    [HideInInspector]
    public Vector3 startPosition;

    public Vector3 Position
    {
        get
        {
            return transform.position;
        }
        set
        {
            transform.position = value;
        }
    }
    [HideInInspector]
    public Vector3 LastPosition;

    [HideInInspector]
    public Vector3 Force;

    [HideInInspector]
    public Vector3 Velocity;

}

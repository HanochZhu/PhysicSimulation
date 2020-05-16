using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring 
{
    public Mass Mass1;
    public Mass Mass2;

    public float KValue;// k
    public float RestLength;

    // 由MASS1指向mass2
    public Vector3 GetCurentLength()
    {
        return Mass2.Position - Mass1.Position;
    }

}

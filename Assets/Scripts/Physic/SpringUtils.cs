using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringUtils 
{

    public Vector3 SpringForce(float factor,Vector3 interval)
    {

        // hooke method
        return -factor * interval;
    }
}

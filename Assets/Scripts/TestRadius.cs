using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRadius : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 p1 = new Vector3(-3,0, 4);
        Vector3 p2 = new Vector3(4,0, 5);
        Vector3 p3 = new Vector3(1,0, -4);

        float r = R(p1,p2,p3);
    }

    public static float A(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        // x,z
        float x1 = p1.x;
        float y1 = p1.z;
        float x2 = p2.x;
        float y2 = p2.z;
        float x3 = p3.x;
        float y3 = p3.z;

        return x1 * (y2 - y3) - y1 * (x2 - x3) + x2 * y3 - x3 * y2;
    }

    public static float B(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        // x,z
        float x1 = p1.x;
        float y1 = p1.z;
        float x2 = p2.x;
        float y2 = p2.z;
        float x3 = p3.x;
        float y3 = p3.z;

        float b11 = (x1 * x1 + y1 * y1) * (y3 - y2);
        float b12 = (x2 * x2 + y2 * y2) * (y1 - y3);
        float b13 = (x3 * x3 + y3 * y3) * (y2 - y1);

        return b11 + b12 + b13;
    }

    public static float C(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        // x,z
        float x1 = p1.x;
        float y1 = p1.z;
        float x2 = p2.x;
        float y2 = p2.z;
        float x3 = p3.x;
        float y3 = p3.z;

        float c11 = (x1 * x1 + y1 * y1) * (x2 - x3);
        float c12 = (x2 * x2 + y2 * y2) * (x3 - x1);
        float c13 = (x3 * x3 + y3 * y3) * (x1 - x2);

        return c11 + c12 + c13;
    }

    public static float D(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        // x,z
        float x1 = p1.x;
        float y1 = p1.z;
        float x2 = p2.x;
        float y2 = p2.z;
        float x3 = p3.x;
        float y3 = p3.z;

        float d11 = (x1 * x1 + y1 * y1) * (x3 * y2 - x2 * y3);
        float d12 = (x2 * x2 + y2 * y2) * (x1 * y3 - x3 * y1);
        float d13 = (x3 * x3 + y3 * y3) * (x2 * y1 - x1 * y2);

        return d11 + d12 + d13;
    }

    public static float R(float A, float B, float C, float D)
    {

        return Mathf.Sqrt((B * B + C * C - 4 * A * D) / (4 * A * A));
    }

    public static float R(Vector3 p1, Vector3 p2, Vector3 p3)
    {

        float x1 = p1.x;
        float y1 = p1.z;
        float x2 = p2.x;
        float y2 = p2.z;
        float x3 = p3.x;
        float y3 = p3.z;

        float A = x1 * (y2 - y3) - y1 * (x2 - x3) + x2 * y3 - x3 * y2;

        float b11 = (x1 * x1 + y1 * y1) * (y3 - y2);
        float b12 = (x2 * x2 + y2 * y2) * (y1 - y3);
        float b13 = (x3 * x3 + y3 * y3) * (y2 - y1);

        float B =  b11 + b12 + b13;

        float c11 = (x1 * x1 + y1 * y1) * (x2 - x3);
        float c12 = (x2 * x2 + y2 * y2) * (x3 - x1);
        float c13 = (x3 * x3 + y3 * y3) * (x1 - x2);

        float C =  c11 + c12 + c13;

        float d11 = (x1 * x1 + y1 * y1) * (x3 * y2 - x2 * y3);
        float d12 = (x2 * x2 + y2 * y2) * (x1 * y3 - x3 * y1);
        float d13 = (x3 * x3 + y3 * y3) * (x2 * y1 - x1 * y2);

        float D = d11 + d12 + d13;

        return Mathf.Sqrt((B * B + C * C - 4 * A * D) / (4 * A * A));
    }
}

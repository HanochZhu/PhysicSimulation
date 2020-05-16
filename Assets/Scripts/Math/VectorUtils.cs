using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorUtils
{

    /// <summary>
    /// 1      0       0       0
    /// 0   con0     -sin0     0
    /// 0   sin0      cons0    0
    /// 0      0       0       1
    /// </summary>
    /// <param name="angle"> in radians </param>
    /// <returns></returns>
    public static Matrix4x4 GetRotateXMaterix(float angle)
    {

        Vector4 col1 = new Vector4(1,           0,          0,                  0);
        Vector4 col2 = new Vector4(0,   Mathf.Cos(angle), -Mathf.Sin(angle),    0);
        Vector4 col3 = new Vector4(0,   Mathf.Sin(angle), Mathf.Cos(angle),     0);
        Vector4 col4 = new Vector4(0,           0,          0,                  1);

        Matrix4x4 rotMat = new Matrix4x4(col1, col2, col3,col4);
        return rotMat;
    }

    /// <summary>
    /// con0    0     sin0     0
    /// 0       1      0       0
    /// -sin0   0    cons0     0
    /// 0       0      0       1
    /// </summary>
    /// <param name="angle"> in radians </param>
    /// <returns></returns>
    public static Matrix4x4 GetRotateYMaterix(float angle)
    {
        Vector4 col1 = new Vector4(Mathf.Cos(angle),        0,      Mathf.Sin(angle),      0);
        Vector4 col2 = new Vector4(0,                       1,           0,                 0);
        Vector4 col3 = new Vector4(-Mathf.Sin(angle),        0,      Mathf.Cos(angle),       0);
        Vector4 col4 = new Vector4(0,                       0,          0,                  1);

        Matrix4x4 rotMat = new Matrix4x4(col1, col2, col3, col4);
        return rotMat;
    }

    /// <summary>
    /// cos0    -sin0     0        0\n
    /// sin0     cos0     0        0\n
    /// 0         0       1        0\n
    /// 0         0       0        1\n
    /// </summary>
    /// <param name="angle"> in radians </param>
    /// <returns></returns>
    public static Matrix4x4 GetRotateZMaterix(float angle)
    {
        // vector is row-type vector
        Vector4 col1 = new Vector4(Mathf.Cos(angle),    -Mathf.Sin(angle),   0,          0);
        Vector4 col2 = new Vector4(Mathf.Sin(angle),   Mathf.Cos(angle),   0,          0);
        Vector4 col3 = new Vector4(0,                   0,                  1,          0);
        Vector4 col4 = new Vector4(0,                   0,                  0,          1);

        Matrix4x4 rotMat = new Matrix4x4(col1, col2, col3, col4);
        return rotMat;
    }
    public static Vector3 RotationAround(this Vector3 self,Vector3 originPoint,Vector3 angle,bool isClockWise = true)
    {
        Vector4 director = self - originPoint;
        Matrix4x4 rotMatX = GetRotateXMaterix(angle[0]);
        Matrix4x4 rotMatY = GetRotateYMaterix(angle[1]);
        Matrix4x4 rotMatZ = GetRotateZMaterix(angle[2]);

        return rotMatX * rotMatY *rotMatZ * director;
    }

    /// <summary>
    /// rotate by single axie
    /// </summary>
    /// <param name="self"></param>
    /// <param name="originPoint"></param>
    /// <param name="zangle"></param>
    /// <param name="isClockWise"></param>
    /// <returns></returns>
    public static Vector3 RotationAroundZ(this Vector3 self, Vector3 originPoint, float zangle, bool isClockWise = true)
    {
        Vector4 director = self - originPoint;
        Matrix4x4 rotMat = GetRotateZMaterix(zangle);
        return rotMat * director;
    }

    public static Vector3 RotationAroundX(this Vector3 self, Vector3 originPoint, float xangle, bool isClockWise = true)
    {
        Vector4 director = self - originPoint;
        Matrix4x4 rotMat = GetRotateXMaterix(xangle);
        return rotMat * director;
    }

    public static Vector3 RotationAroundY(this Vector3 self, Vector3 originPoint, float yangle, bool isClockWise = true)
    {
        Vector4 director = self - originPoint;
        Matrix4x4 rotMat = GetRotateXMaterix(yangle);
        return rotMat * director;
    }

}

using System;
using UnityEngine;

namespace Assets.Scripts.Physic
{
    static class PhysicUtils
    {

        public static float Cos(Vector3 a,Vector3 b)
        {
            return Vector3.Dot(a, b) / (a.magnitude * b.magnitude);
        }

        public static Vector3 GetNextPosition(Vector3 force, ref Vector3 curVelocity, float dt, Vector3 curPosition,float mass)
        {
            Vector3 accelerate = force / mass;

            Vector3 nextVelocity = GetNextVelocity(curVelocity, accelerate, dt);

            Vector3 deltaPos = curVelocity * dt;

            Vector3 nextPos = curPosition + deltaPos;

            curVelocity = nextVelocity;

            return nextPos;
        }

        //next velocity under a extra force
        public static Vector3 GetNextVelocity(Vector3 v0, Vector3 a, float dt)
        {
            return v0 + a * dt;
        }
    }
}

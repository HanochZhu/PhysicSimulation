using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MethodType
{
    Euler,
    Verlet
}

public class Rope : MonoBehaviour
{
    public Vector3 Gravity;
    public float Springk;
    public float AirResistanceFactor;
    public float SpingRestLength;


    public List<Mass> Masses;
    public List<Spring> Springs;

    public MethodType MethodType;
    
    private void Start()
    {
        Masses = new List<Mass>();
        Springs = new List<Spring>();
        InitMass();
    }

    public void InitMass()
    {
        // 初始化质点
        Masses = new List<Mass>(this.GetComponentsInChildren<Mass>());

        Masses[0].isPined = true;

        for (int i = 1; i < Masses.Count; i++)
        {
            Spring s = new Spring();
            s.Mass1 = Masses[i - 1];
            s.Mass2 = Masses[i];
            s.KValue = Springk;
            s.RestLength = float.Equals(SpingRestLength, 0) ? (s.Mass1.Position - s.Mass2.Position).magnitude: SpingRestLength;
            Springs.Add(s);
        }
    }

    private void FixedUpdate()
    {
        if (MethodType == MethodType.Euler)
        {
            ExplicitEulerMathod(Time.fixedDeltaTime);
        }
        else
        {
            VerletMathod(Time.fixedDeltaTime);
        }
    }

    // Euler
    // Most integral mathod have convergance feature
    // So In Explicit Euler Mathod , 
    // I give a air resistance to speed up the aconvergance
    public void ExplicitEulerMathod(float deltaTime)
    {
        foreach (var item in Springs)
        {
            // euler
            // spring force

            Vector3 spingforce = Springk * item.GetCurentLength().normalized * (item.GetCurentLength().magnitude - item.RestLength);
            item.Mass1.Force += spingforce;
            item.Mass2.Force -= spingforce;
            Debug.DrawLine(item.Mass1.Position, item.Mass2.Position);
        }

        foreach (var item in Masses)
        {
            if (!item.isPined)
            {
                item.Force += Gravity;
                item.Force -= item.Velocity * AirResistanceFactor;

                item.Velocity += (item.Force / item.MassValue) * deltaTime;
                item.Position += item.Velocity * deltaTime;
            }
            item.Force = Vector3.zero;
        }
    }

    // Verlet mathod
    // 
    public void VerletMathod(float deltaTime)
    {
        // first , get the final position of mass
        // second , constraint the positon to the rest length

        foreach (var item in Masses)
        {
            if (!item.isPined)
            {
                Vector3 tempPosition = item.Position;

                item.Force = Gravity;
                
                item.Position += (1f - AirResistanceFactor) * (item.Position - item.LastPosition) + (item.Force / item.MassValue) * deltaTime * deltaTime;

                item.LastPosition = tempPosition;
            }
        }
        foreach (var item in Springs)
        {
            Vector3 subtract = item.Mass1.Position - item.Mass2.Position;
            subtract = subtract.normalized * (subtract.magnitude - item.RestLength);

            if (item.Mass1.isPined)
            {
                item.Mass2.Position += subtract;
            }
            else if (item.Mass2.isPined)
            {
                item.Mass1.Position -= subtract;
            }
            else
            {
                item.Mass1.Position -= subtract/2.0f;
                item.Mass2.Position += subtract/2.0f;
            }
            Debug.DrawLine(item.Mass1.Position, item.Mass2.Position);
        }
    }
}

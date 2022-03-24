using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class PlayerRopeSettings : MonoBehaviour
{
    public DynamicJoystick dynamicJoystick;
    public ObiSolver obiSolver;
    public float speed = 0.001f;
    public static float newvalue;

    public Oni.ConstraintParameters parameters;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((obiSolver.distanceConstraintParameters.SORFactor<1.7f)&& (obiSolver.distanceConstraintParameters.SORFactor>0.2f))
        {
            obiSolver.distanceConstraintParameters.SORFactor += dynamicJoystick.Vertical * speed*Time.deltaTime;
            obiSolver.PushSolverParameters();
        }
        if (obiSolver.distanceConstraintParameters.SORFactor > 1.7) obiSolver.distanceConstraintParameters.SORFactor = 1.6f;
        if (obiSolver.distanceConstraintParameters.SORFactor < 0.2) obiSolver.distanceConstraintParameters.SORFactor = 0.3f;




    }
    //public void Artma()
    //{
    //    obiSolver.distanceConstraintParameters.SORFactor += 0.1f;
    //    obiSolver.PushSolverParameters();
    //}
    //public void Azalma()
    //{
    //    obiSolver.distanceConstraintParameters.SORFactor -= 0.1f;
    //    obiSolver.PushSolverParameters();
    //}
}

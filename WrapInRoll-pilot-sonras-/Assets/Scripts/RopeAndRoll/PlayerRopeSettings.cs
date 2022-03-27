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

    public Transform hook;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((obiSolver.distanceConstraintParameters.SORFactor<1.8f)&& (obiSolver.distanceConstraintParameters.SORFactor>0.1f))
        {
            obiSolver.distanceConstraintParameters.SORFactor += dynamicJoystick.Vertical * speed*Time.deltaTime;
            obiSolver.PushSolverParameters();
        }
        if (obiSolver.distanceConstraintParameters.SORFactor > 1.9f) obiSolver.distanceConstraintParameters.SORFactor = 1.8f;
        if (obiSolver.distanceConstraintParameters.SORFactor < 0.1f) obiSolver.distanceConstraintParameters.SORFactor = 0.2f;

        if (hook.transform.localScale.x>0.7f&& hook.transform.localScale.x <3.9f)
        {
            hook.transform.localScale +=new Vector3( dynamicJoystick.Vertical * speed * Time.deltaTime, dynamicJoystick.Vertical * speed * Time.deltaTime, dynamicJoystick.Vertical * speed * Time.deltaTime);
        }
        if (hook.transform.localScale.x < 0.7) hook.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        if (hook.transform.localScale.x > 3.9) hook.transform.localScale = new Vector3(3.8f, 3.8f, 3.8f);

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

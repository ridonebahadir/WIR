using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
using UnityEngine.UI;

public class PlayerRopeSettings : MonoBehaviour
{
    public DynamicJoystick dynamicJoystick;
    public ObiSolver obiSolver;
    
    public float speed = 0.001f;
    public static float newvalue;

    public Oni.ConstraintParameters parameters;
    private ObiRopeExtrudedRenderer ropeExtrudedRenderer;
   
    public Transform hook;
    public float distance;
    void Start()
    {
        ropeExtrudedRenderer = hook.GetComponent<ObiRopeExtrudedRenderer>();

        ropeheightText.text = "0,0" + " m";



    }
    public bool rundistance;
    // Update is called once per frame
    public Text ropeheightText;
    void Update()
    {
        if (rundistance)
        {
            ropeheightText.text = ((distance - obiSolver.distanceConstraintParameters.SORFactor * 20) / 5).ToString("F1") + " m";
        }
      

        if ((obiSolver.distanceConstraintParameters.SORFactor<1.7f)&& (obiSolver.distanceConstraintParameters.SORFactor>0.1f))
        {
            obiSolver.distanceConstraintParameters.SORFactor += dynamicJoystick.Vertical * speed*Time.deltaTime;
            obiSolver.PushSolverParameters();
        }
        if (obiSolver.distanceConstraintParameters.SORFactor > 1.7f) obiSolver.distanceConstraintParameters.SORFactor = 1.6f;
        if (obiSolver.distanceConstraintParameters.SORFactor < 0.1f) obiSolver.distanceConstraintParameters.SORFactor = 0.2f;

        if (ropeExtrudedRenderer.thicknessScale> 0.7f && ropeExtrudedRenderer.thicknessScale < 3.9f)
        {

            ropeExtrudedRenderer.thicknessScale += dynamicJoystick.Vertical * speed * Time.deltaTime;
           
        }
        if (ropeExtrudedRenderer.thicknessScale < 1) ropeExtrudedRenderer.thicknessScale = 1;
        if (ropeExtrudedRenderer.thicknessScale > 4) ropeExtrudedRenderer.thicknessScale = 3.8f;
       
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

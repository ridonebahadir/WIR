using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LineDistance : MonoBehaviour
{
    public LineRenderer lineRend2;
    public TextMesh distanceText;
    private Transform tutunma;
    public Transform player;
    public Transform dolanma;
   
    public GameManager gm;
    private int level;
    public bool beforeText;
    private Vector3 textPos;
    void Start()
    {

        level = gm.level;
        
        tutunma = dolanma.transform.GetChild(level - 1).GetChild(1).GetChild(0).gameObject.transform;
       
       
       
    }

    
    void Update()
    {
       
        
        if (beforeText)
        {
            distanceText.transform.parent = null;
            DontDestroyOnLoad(distanceText.gameObject);
            distanceText.transform.position = textPos;
            distanceText.color = new Color(distanceText.color.r, distanceText.color.g, distanceText.color.b, 0.3f);
        }
        else
        {
            DrawLineDistance(lineRend2, player.position, new Vector3(player.position.x, tutunma.position.y, tutunma.position.z), distanceText);
            textPos = distanceText.transform.position;
            

        }
    }
    public void DrawLineDistance(LineRenderer line,Vector3 pos,Vector3 pos2, TextMesh distanceText)
    {
        float distance;
        line.SetPosition(0, pos);
        line.SetPosition(1, pos2);
        distance = (pos - pos2).magnitude;
        distanceText.transform.position = (line.GetPosition(0) + line.GetPosition(1)) / 2;
        distanceText.text = distance.ToString("F0") + " Meters";
    }
}

using UnityEngine;
using System.Collections;

public class DynamicAddLineSample_Normal : MonoBehaviour {

	public bool OnSurface = false;
	private Vector3 hitPos;

	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			GameObject hitObj = MouseRayer.GetMouseRayHit(Camera.main, out hitPos);
			if (hitObj!=null)
			{
				if (!OnSurface)
				{
					MeasureLine.DrawLine(hitObj.transform, false, OnSurface);
				}
				else
				{
					GameObject hitDummy = new GameObject("SurfaceLineDummy");
					hitDummy.transform.position = hitPos;
					hitDummy.transform.SetParent(hitObj.transform);
					MeasureLine.DrawLine(hitDummy.transform, false, OnSurface);
				}
			}
		}
		else if (Input.GetKeyDown(KeyCode.Mouse1))
		{
			MeasureLine.EndDrawLine();
		}
		else if (Input.GetKeyDown(KeyCode.Mouse2))
		{
//			MeasureLine.AddLine(GameObject.Find("Icosahedron (1)").transform, GameObject.Find("Icosahedron (3)").transform, false, false);
			MeasureLine.DeleteLine(GameObject.Find("Icosahedron (1)").transform, GameObject.Find("Icosahedron (3)").transform, OnSurface);
		}
	}
}

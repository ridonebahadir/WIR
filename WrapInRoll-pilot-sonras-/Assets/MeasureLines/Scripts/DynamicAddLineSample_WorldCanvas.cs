using UnityEngine;
using System.Collections;

public class DynamicAddLineSample_WorldCanvas : MonoBehaviour {

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
					MeasureLine_WorldCanvas.DrawLine(hitObj.transform, false, false, OnSurface);
				}
				else
				{
					GameObject hitDummy = new GameObject("SurfaceLineDummy");
					hitDummy.transform.position = hitPos;
					hitDummy.transform.SetParent(hitObj.transform);
					MeasureLine_WorldCanvas.DrawLine(hitDummy.transform, false, false, OnSurface);
				}
			}
		}
		else if (Input.GetKeyDown(KeyCode.Mouse1))
		{
			MeasureLine_WorldCanvas.EndDrawLine();
		}
		else if (Input.GetKeyDown(KeyCode.Mouse2))
		{
			MeasureLine_WorldCanvas.DeleteLine(GameObject.Find("Icosahedron (1)").transform, GameObject.Find("Icosahedron (3)").transform, OnSurface);
		}
	}
}

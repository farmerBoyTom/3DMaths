using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRayIntersections : MonoBehaviour 
{
	public GameObject sheep;
	//public Transform corner1, coner2, corner3;
	public GameObject quad;

	Plane mPlane;

	void Start()
	{
		Vector3[] vertices = quad.GetComponent<MeshFilter>().mesh.vertices;
		mPlane = new Plane (quad.transform.TransformPoint(vertices[0]), vertices[1], vertices[2]);
	}

	void Update()
	{
		if(Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			float t = 0.0f;
			if(mPlane.Raycast(ray, out t))
			{
				Vector3 hitPoint = ray.GetPoint (t);
				sheep.transform.position = hitPoint;
			}
		}
	}
}

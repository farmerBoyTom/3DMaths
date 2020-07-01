using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlaneHit : MonoBehaviour {

	public Transform A;
	public Transform B;
	public Transform C;
	public Transform D;
	public Transform E;

	PlaneMath plane;
	Line line;

	void Start()
	{
		plane = new PlaneMath (new Coords(A.position),
			               new Coords(B.position),
			               new Coords(C.position) );

		line = new Line (new Coords(D.position),
			             new Coords(E.position),
			             Line.LINETYPE.RAY);

		line.Draw (1, Color.green);

		for(float s = 0; s <= 1; s += 0.1f)
		{
			for(float t = 0; t <= 1; t += 0.1f)
			{
				GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
				sphere.transform.position = plane.Lerp (s, t).ToVector ();
			}
		}

		float interceptAt = line.IntersectsAt (plane);
		if (interceptAt == interceptAt) 
		{
			GameObject it = GameObject.CreatePrimitive (PrimitiveType.Cube);
			it.transform.position = line.Lerp (interceptAt).ToVector();
		}
	}

}

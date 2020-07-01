using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSolidWall : MonoBehaviour {

	public Transform A;
	public Transform B;
	public Transform C;
	public Transform D;
	public Transform E;

	public Transform ball;

	PlaneMath plane;
	Line line;
	Line trajectory;

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
			trajectory = new Line (line.A, line.Lerp(interceptAt), Line.LINETYPE.SEGMENT);
		}
			
	}

	void Update()
	{
		if (Time.time <= 1) {
			ball.transform.position = trajectory.Lerp (Time.time).ToVector();
		} else {
			ball.transform.position += trajectory.Reflect (TMath.Cross(plane.v, plane.u)).ToVector() * Time.deltaTime * 15;
		}
	}
}

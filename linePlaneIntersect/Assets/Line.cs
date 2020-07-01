using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line
{
    public Coords A, B, v;

    public enum LINETYPE
    {
        LINE,
        SEGMENT,
        RAY
    }

    LINETYPE type;

    public Line(Coords _A, Coords _B, LINETYPE _type)
    {
        A = _A;
        B = _B;
        type = _type;
        v = new Coords(B.x - A.x, B.y - A.y, B.z - A.z);
    }

    public Line(Coords _A, Coords _V)
    {
        A = _A;
        v = _V;
        B = _A + v;
        type = LINETYPE.SEGMENT;
    }


	public float IntersectsAt(PlaneMath plane)
	{
		Coords N = TMath.Cross (plane.u, plane.v);
		Coords AB = plane.A - A;

		if (TMath.Dot (N, v) == 0)
			return float.NaN;
		
		float t = TMath.Dot (N, AB) / TMath.Dot (N, v);

		return t;
	}

    public float IntersectsAt(Line l)
    {
        if(TMath.Dot(Coords.Perp(l.v), v) == 0)
        {
            return float.NaN;
        }

        Coords c = l.A - this.A;
        float t = TMath.Dot(Coords.Perp(l.v), c) / TMath.Dot(Coords.Perp(l.v), v);

        if(t < 0 || t > 1 && type == LINETYPE.SEGMENT)
        {
            return float.NaN;
        }

        return t;
    }

    public void Draw(float width, Color col)
    {
        Coords.DrawLine(A, B, width, col);
    }

    public Coords Lerp(float t)
    {
        if (type == LINETYPE.SEGMENT)
            t = Mathf.Clamp(t, 0, 1);
        else if (type == LINETYPE.RAY && t < 0)
            t = 0;

        float xt = A.x + v.x * t;
        float yt = A.y + v.y * t;
        float zt = A.z + v.z * t;

        return new Coords(xt, yt, zt);
    }

	public Coords Reflect(Coords normal)
	{
		//R = A - 2(A.N)N
		Coords norm = normal.GetNormal();
		Coords vnorm = v.GetNormal ();

		float d = TMath.Dot (norm, vnorm) * 2;

		if (d == 0)
			return v;

		return vnorm - norm * d;
	}

}

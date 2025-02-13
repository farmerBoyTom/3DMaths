﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMath : MonoBehaviour
{
    public Coords A;
    public Coords B;
    public Coords C;
    public Coords v;
    public Coords u;

    public PlaneMath(Coords _A, Coords _B, Coords _C)
    {
        A = _A;
        B = _B;
        C = _C;
        v = B - A;
        u = C - A;
    }

    public PlaneMath(Coords _A, Vector3 V, Vector3 U)
    {
        A = _A;
        v = new Coords(V.x, V.y, V.z);
        u = new Coords(U.x, U.y, U.z);
    }

    public Coords Lerp(float s, float t)
    {
        float xst = A.x + v.x * s + u.x * t;
        float yst = A.y + v.y * s + u.y * t;
        float zst = A.z + v.z * s + u.z * t;

        return new Coords(xst, yst, zst);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class TMath
{
    static public float Square(float value)
    {
        return value * value;
    }

    static public float Distance(Coords point1, Coords point2)
    {
        float diffSquared = Square(point1.x - point2.x) + 
                            Square(point1.y - point2.y) + 
                            Square(point1.z - point2.z);
        float squareRoot = Mathf.Sqrt(diffSquared);
        return squareRoot;
    }

    static public Coords Lerp(Coords A, Coords B, float t)
    {
        t = Mathf.Clamp(t, 0, 1);

        Coords v = new Coords(B.x - A.x, B.y - A.y, B.z - A.z);

        float xt = A.x + v.x * t;
        float yt = A.y + v.y * t;
        float zt = A.z + v.z * t;

        return new Coords(xt, yt, zt);
    }

    static public Coords GetNormal(Coords vector)
    {
        float length = Distance(new Coords(0, 0, 0), vector);
        vector.x /= length;
        vector.y /= length;
        vector.z /= length;

        return vector;
    }

    static public float Dot(Coords vector1, Coords vector2)
    {
        return (vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z);
    }

    //Returns radians
    static public float Angle(Coords vector1, Coords vector2)
    {
        float dotDivide = Dot(vector1, vector2) / (Distance(new Coords(0, 0, 0), vector1) * Distance(new Coords(0, 0, 0), vector2));
        return Mathf.Acos(dotDivide);
    }

    static public Coords Cross(Coords vector1, Coords vector2)
    {
        float x = vector1.y * vector2.z - vector1.z * vector2.y;
        float y = vector1.z * vector2.x - vector1.x * vector2.z;
        float z = vector1.x * vector2.y - vector1.y * vector2.x;
        Coords crossProd = new Coords(x, y, z);
        return crossProd;
    }

    //The angle must be in radians
    static public Coords Rotate(Coords vector, float angle, bool clockwise)
    {
        if (clockwise)
            angle = 2 * Mathf.PI - angle;

        float xValue = vector.x * Mathf.Cos(angle) - vector.y * Mathf.Sin(angle);
        float yValue = vector.x * Mathf.Sin(angle) + vector.y * Mathf.Cos(angle);
        return new Coords(xValue, yValue, 0); 
    }
}

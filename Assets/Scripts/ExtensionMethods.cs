using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hackman_GD07;

public static class ExtensionMethods
{
    public static Vector3 ToVector3(this IntVector2 vector2)
    {
        return new Vector3(vector2.x, vector2.y);
    }
    public static IntVector2 ToIntVector2(this Vector3 vector3)
    {
        return new IntVector2((int)vector3.x, (int)vector3.y);
    }
    public static bool IsWall(this IntVector2 vector2)
    {
        return LevelGeneratorSystem.Grid[Mathf.Abs(vector2.y), Mathf.Abs(vector2.x)] == 1;
    }
}

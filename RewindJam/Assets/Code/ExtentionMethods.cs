using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtentionMethods
{
    public static Vector2 With(this Vector2 vector, float? x = null, float? y = null)
    {
        return new Vector2(x ?? vector.x, y ?? vector.y);
    }

    public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null)
    {
        return new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);
    }

    public static Quaternion Set2DRotation(this Quaternion q, float z)
    {
        return Quaternion.Euler(0f, 0f, z);
    }
    public static Quaternion AddRotation(this Quaternion q, float dz)
    {
        return Quaternion.Euler(0f, 0f, q.eulerAngles.z + dz);
    }
}

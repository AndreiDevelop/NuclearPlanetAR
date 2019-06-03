using UnityEngine;

public static class Vector3Extension
{
    public static void Clamp(this Vector3 original, float min, float max)
    {
        Vector3 bufOriginal = original;
        original = new Vector3(Mathf.Clamp(bufOriginal.x, min, max), Mathf.Clamp(bufOriginal.y, min, max), Mathf.Clamp(bufOriginal.z, min, max));
    }

    public static Vector3 ClampGet(this Vector3 original, float min, float max)
    {
        return new Vector3(Mathf.Clamp(original.x, min, max), Mathf.Clamp(original.y, min, max), Mathf.Clamp(original.z, min, max));
    }
}

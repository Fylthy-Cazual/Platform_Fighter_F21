using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils 
{
    public static IEnumerator Frames(int frameCount)
    {
        while (frameCount > 0)
        {
            frameCount--;
            yield return new WaitForEndOfFrame();
        }
    }

    public static IEnumerator VelocityFrames(Transform transform, Vector2 velocity, int frameCount)
    {
        while (frameCount > 0)
        {
            frameCount--;
            transform.position += (Vector3) velocity;
            yield return new WaitForEndOfFrame();
        }
    }

    // public static IEnumerator exist(int frames)
    // {

    // }
}

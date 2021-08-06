using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils 
{
    public static IEnumerator Frames(int frameCount)
    {
        while (frameCount > 0f)
        {
            frameCount--;
            yield return new WaitForEndOfFrame();
        }
    }

    // public static IEnumerator exist(int frames)
    // {

    // }
}

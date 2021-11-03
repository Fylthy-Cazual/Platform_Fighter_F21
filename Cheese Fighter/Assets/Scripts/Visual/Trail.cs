using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    public SpriteRenderer sr;
    private float duration;

    // Start is called before the first frame update
    void Start()
    {
        duration = 1f;
        StartCoroutine(exist());
    }

    IEnumerator exist()
    {
        while (duration > 0f)
        {
            sr.color = new Color (1f, 1f, 1f, duration);
            duration -= 0.01f;
            yield return Utils.Frames(1);
        }
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRing : MonoBehaviour
{
    private float timer = 27f;
    private float width = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(exist());
    }

    IEnumerator exist()
    {
        while (timer > 0f)
        {
            transform.localScale = new Vector3(width, 1f, 1f);
            width += 0.2f;
            timer -= 1f;
            yield return Utils.Frames(1);
        }
        Destroy(gameObject);
    }
}

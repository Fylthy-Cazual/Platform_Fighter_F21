using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WesternStage : MonoBehaviour
{
    public Material[] skyboxes;
    public float period_length;
    private int index;
    public float timer;
    private SpriteRenderer[] srs;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        timer = 0f;
        srs = FindObjectsOfType<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > period_length) 
        {
            RenderSettings.skybox = skyboxes[index];
            switch (index) 
            {
                case 0:
                    foreach (SpriteRenderer sr in srs)
                    {
                        sr.color = new Color(sr.color[0] - 0.2f, sr.color[1] - 0.2f, sr.color[2] - 0.2f);
                    }
                    break;
                case 1:
                    foreach (SpriteRenderer sr in srs)
                    {
                        sr.color = new Color(sr.color[0] - 0.8f, sr.color[1] - 0.8f, sr.color[2] - 0.8f);
                    }
                    break;
                case 2:
                    foreach (SpriteRenderer sr in srs)
                    {
                        sr.color = new Color(sr.color[0] + 0.8f, sr.color[1] + 0.8f, sr.color[2] + 0.8f);
                    }
                    break;
                case 3:
                    foreach (SpriteRenderer sr in srs)
                    {
                        sr.color = new Color(sr.color[0] + 0.2f, sr.color[1] + 0.2f, sr.color[2] + 0.2f);
                    }
                    break;
                default:
                    break;
            }
            index++;
            timer = 0f;
            if (index >= skyboxes.Length) index = 0;
            
        }
    }
}

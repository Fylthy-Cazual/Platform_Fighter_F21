using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Rat[] allPlayers;
    // Start is called before the first frame update
    void Start()
    {
        allPlayers = FindObjectsOfType<Rat>();
        this.transform.position = new Vector3(0f, 0f, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(0f, 0f, -10f);
        Vector3 center = new Vector3(0f, 0f, 0f);
        float maxDist = 0f;
        foreach (Rat rat in allPlayers)
        {
            newPos.x = newPos.x + rat.transform.position.x;
            newPos.y = newPos.y + rat.transform.position.y;
            float thisDist = Vector3.Distance(rat.transform.position, center);
            if (thisDist > maxDist) 
            {
                maxDist = thisDist;
            }
        }
        newPos.x = newPos.x / allPlayers.Length;
        newPos.y = newPos.y / allPlayers.Length;
        newPos.z = -10f - (maxDist * 3);
        this.transform.position = newPos;
    }
}

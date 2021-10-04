using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfMap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Console.WriteLine("poggers");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Called when collider collides with another collider
    private void OnTriggerEnter(Collider c) {
        //kill rat somehow idk
        Destroy(c.gameObject);
        Console.WriteLine("poggers");
    }
}

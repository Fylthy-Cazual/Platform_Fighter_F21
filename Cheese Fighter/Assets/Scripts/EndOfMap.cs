using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfMap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Called when collider collides with another collider
    private void OnTriggerEnter2D(Collider2D c) {
        Rat rat = c.gameObject.GetComponent<Rat>();
        rat.die();
    }
}

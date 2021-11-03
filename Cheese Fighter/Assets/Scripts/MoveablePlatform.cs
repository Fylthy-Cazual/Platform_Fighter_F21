using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveablePlatform : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField]
    private float Time;
    private bool isMoving = false;
    private float reset;
    private float movementSpeed = 5f;
    //positon and velocity in vector 3
    //velocity == vector 3 going 
    //velocity = Vector3(2f, 0f, 0f)
    //keep track of two positions
    //.velocity in a certain vector
    // Start is called before the first frame update
    void Start()
    {
        //set timer variable to perfect time
        //secs var set up
        reset = Time;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if( Time > 0){
            Time -= 1;
        }
        else{
            if(gameObject.transform.position.x < 0 )
            {
                rb.velocity = new Vector3(10, 0, 0);
            }
            else if(gameObject.transform.position.x > 0)
            {
                rb.velocity = new Vector3(-10,0,0);
            }
            //if position is in the left side
                //move to the right
            //elif position is in the right or middle
                //move to the left
            //reset time to the time it was before
            //move either left to right or right to left
            //once movement is done or at a position I want reset time
            Time = reset;
        }
        
    }
}



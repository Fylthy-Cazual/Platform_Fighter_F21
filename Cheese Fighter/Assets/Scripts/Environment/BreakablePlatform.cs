using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    [SerializeField]
    private float timer; 
    // Start is called before the first frame update
    void Start()
    {
        //set timer variable to 5 seconds(or whatever is the fps it is)
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0){
            //does nothing
            timer -= 1;
        }
        else{
            //breakapart
            Destroy(gameObject);

        }

        //maybe make the if question for it here
        //if out of range: remove platform, and if character still on platform be dropped straight down to the stage of where platform is hovering over
        //else counter-1,
        
    }
}

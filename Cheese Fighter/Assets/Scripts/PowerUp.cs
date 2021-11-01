using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    //This script exists!
    [SerializeField] private float time; 
    [SerializeField] private bool picked_up;
    private Rat user;

    // Start is called before the first frame update
    void Start()
    {
        picked_up = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(picked_up)
        {   

            time -= 1f;
            if (time <= 0)
            {
                PowerDown();
                Destroy(gameObject);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.GetComponent<Rat>())
        {
            picked_up = true;
            user = col.gameObject.GetComponent<Rat>();
            PowerUpMethod();
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void PowerUpMethod()
    {
        switch(this.name)
        {
        case "JumpBuff":
            user.maxJumps += 1;
            break;
        case "DamageBuff":
            //dmgMultiplier = dmgMultiplier * 2;
            break;
        case "InvisibleBuff":
            user.GetComponent<SpriteRenderer>().enabled = false;
            break;
        case "SpeedBuff":
            user.speed *= 1.5f;
            break;
        default:
            break;
        }
    }

    void PowerDown()
    {
        switch(this.name)
        {
        case "JumpBuff":
            user.maxJumps -= 1;
            break;
        case "DamageBuff":
            //dmgMultiplier /= 2;
            break;
        case "InvisibleBuff":
            user.GetComponent<SpriteRenderer>().enabled = true;
            break;
        case "SpeedBuff":
            user.speed /= 1.5f;
            break;
        default:
            break;
        }
    }
}

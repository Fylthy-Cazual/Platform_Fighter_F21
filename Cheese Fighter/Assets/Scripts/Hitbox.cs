using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public bool visible;

    private SpriteRenderer sr;

    private Transform attacker;
    private float xPos;
    private float yPos;
    private float width;
    private float height;
    private int duration;
    private float damage;
    private float xLaunch;
    private float yLaunch;
    private float hitstun;
    private float blockstun;
    
    private BoxCollider2D bc;

    public void setHitbox(Transform myAttacker, string myAttackerTag, float myXpos, float myYpos,
                float myWidth, float myHeight, int myDuration, float myDamage, float myXLaunch, float myYLaunch,
                float myHitstun, float myBlockstun)
    {
        attacker = myAttacker;
        gameObject.tag = myAttackerTag;
        xPos = myXpos;
        yPos = myYpos;
        width = myWidth;
        height = myHeight;
        duration = myDuration;
        damage = myDamage;
        xLaunch = myXLaunch;
        yLaunch = myYLaunch;
        hitstun = myHitstun;
        blockstun = myBlockstun;

        bc = gameObject.GetComponent<BoxCollider2D>();
        //bc.size = new Vector2(width, height);
        transform.localScale = new Vector3(width, height, 1f);
        // if (visible)
        // {
        //     sr = gameObject.GetComponent<SpriteRenderer>();
        //     transform.localScale = new Vector3(width, height, 0f);
        //     sr.enabled = true;
        // }
        StartCoroutine(exist());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(attacker.position.x + xPos,
                                        attacker.position.y + yPos,
                                        attacker.position.z);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag != gameObject.tag && col.tag[0] == 'p') //All players have tags like 'p0', 'p1', 'p2', etc. Mind the lowercase!
        {
           Debug.Log("gotcha!");
           Rat enemy = col.gameObject.GetComponent<Rat>();
           enemy.takeDmg(damage);
           enemy.launch2(xLaunch, yLaunch);
           Destroy(gameObject);
        }
    }

    IEnumerator exist()
    {
        yield return Utils.Frames(duration);
        Destroy(gameObject);
    }
}

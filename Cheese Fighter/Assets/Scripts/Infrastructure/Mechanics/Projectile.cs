using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Hitbox
{
    private float speedX;
    private float speedY;

    private SpriteRenderer projectileSR;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + speedX,
                                        transform.position.y + speedY,
                                        0f);
    }

    public void setSpeedX(float speed)
    {
        spawn();
        this.speedX = speed;
    }

    public void setSpeedY(float speed)
    {
        spawn();
        this.speedY = speed;
    }

    public void setSpeed(float speedX, float speedY)
    {
        spawn();
        this.speedX = speedX;
        this.speedY = speedY;
    }

    public void setSprite(Sprite sprite)
    {
        //change sprite of this projectile
    }

    public void flip()
    {
        SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();
        projectileSR = srs[1];
        projectileSR.flipX = true;
    }
    
}

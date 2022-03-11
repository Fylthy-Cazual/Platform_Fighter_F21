using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Hitbox
{
    public ParticleSystem[] sideVFX;
    public ParticleSystem[] impactVFX;

    private List<ParticleSystem> _sideVFX = new List<ParticleSystem>();

    private float speedX;
    private float speedY;

    private SpriteRenderer projectileSR;

    private void Start()
    {
        foreach (ParticleSystem vfx in sideVFX)
        {
            _sideVFX.Add(Instantiate(vfx, transform));
        }
    }

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
        if (srs.Length > 1)
        {
            projectileSR = srs[1];
            projectileSR.flipX = true;
        }
    }

    protected override void SelfDestruct(bool isCollision)
    {
        foreach (ParticleSystem vfx in _sideVFX)
        {
            vfx.transform.SetParent(null, true);
            vfx.transform.localScale = new Vector3(1, 1, 1);
            vfx.Stop();
        }
        if (isCollision)
        {
            foreach (ParticleSystem vfx in impactVFX)
            {
                Instantiate(vfx, transform.position, Quaternion.identity);
            }
        }

        base.SelfDestruct(isCollision);
    }
}

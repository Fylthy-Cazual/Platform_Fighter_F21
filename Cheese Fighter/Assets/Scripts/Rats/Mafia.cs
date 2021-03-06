using System.Collections;
using UnityEngine;

public class Mafia : Rat
{

    // -------------------------------------------------------------------------- STATIC MEMBERS
    #region STATIC MEMBERS
    #endregion

    // -------------------------------------------------------------------------- SERIALIZABLE INSPECTOR
    #region SERIALIZABLE INSPECTOR
    public Projectile groundedNormal;
    public Projectile groundedSpecial;
    public ParticleSystem groundedNormalChargeVFX;
    public ParticleSystem[] groundedSpecialChargeVFX;
    #endregion

    // -------------------------------------------------------------------------- INSTANCE PROPERTIES
    #region INSTANCE PROPERTIES
    #endregion

    // -------------------------------------------------------------------------- GETTERS AND SETTERS
    #region GETTERS AND SETTERS
    #endregion

    // -------------------------------------------------------------------------- INITIALIZATION
    #region INITIALIZATION
    #endregion

    // -------------------------------------------------------------------------- METHODS AND ROUTINES
    #region METHODS AND ROUTINES
    protected override IEnumerator jabG() //grounded normal attack
    {

        action = true;
        animator.SetTrigger(Jab_Ground);

        if (dir < 0)
        {
            Instantiate(groundedNormalChargeVFX, transform.position + Vector3.left * 0.6f, Quaternion.identity, transform);
        }
        else
        {
            Instantiate(groundedNormalChargeVFX, transform.position + Vector3.right * 0.6f, Quaternion.identity, transform);
        }
        yield return Utils.Frames(45);
        Projectile p = makeProjectile(0.3f * dir, 0f, 5f, 
            5f, 30, 30, 
            3f * dir, 0.5f, 5, 
            2, groundedNormal); //How can we increase the range to make the jab a "shooting" action?
        p.setSpeedX(0.25f * dir); //Jerry will this increase the speed? We can't tell because the animation will play at a constant rate.
        if (dir < 0) p.flip();
        yield return Utils.Frames(10);
        action = false;
        animator.SetTrigger(Return);
    }

    protected override IEnumerator jabA() //aerial normal attack
    {
        action = true;
        animator.SetTrigger(Jab_Air);
        if (dir < 0)
        {
            Instantiate(groundedNormalChargeVFX, transform.position + Vector3.left * 0.6f, Quaternion.identity, transform);
        }
        else
        {
            Instantiate(groundedNormalChargeVFX, transform.position + Vector3.right * 0.6f, Quaternion.identity, transform);
        }
        yield return Utils.Frames(45);
        Projectile p = makeProjectile(0.3f * dir, 0f, 1.6f, 
            5f, 30, 30, 
            3f * dir, 0.5f, 5, 
            2, groundedNormal); //How can we increase the range to make the jab a "shooting" action?
        p.setSpeedX(0.25f * dir); //Jerry will this increase the speed? We can't tell because the animation will play at a constant rate.
        if (dir < 0) p.flip();
        yield return Utils.Frames(10);
        action = false;
        animator.SetTrigger(Return);
        /* Don't have the assets for this one yet
        //Slam straight down (USE SCOTT'S WORK FOR THE COWBOY)

        // PARAMS
        const int setupDuration = 28;
        const int dashDuration = 3;
        const float setupSpeed = 0.1f;
        const float dashSpeed = 0.1f;

        action = true;
        animator.SetTrigger(Jab_Air);
        yield return Utils.Frames(10);

        while (!collidingY)
        {
            rb.AddForce(new Vector3(0, -2f, 0));
            yield return Utils.Frames(1);
        }

        yield return Utils.Frames(10);
        Projectile p = makeProjectile(0.3f * dir, 0f, 1.6f, 
            5f, 10, 30, 
            3f * dir, 0.5f, 5, 
            2); //How can we increase the range to make the jab a "shooting" action?
        p.setSpeedX(0.8f * dir); //Jerry will this increase the speed? We can't tell because the animation will play at a constant rate.
        if (dir < 0) p.flip();
       

        Projectile d = makeProjectile(0.3f * dir, 0f, 1.6f, 
            5f, 10, 30, 
            3f * -dir, 0.5f, 5, 
            2); //How can we increase the range to make the jab a "shooting" action?
        d.setSpeedX(0.8f * -dir); //Jerry will this increase the speed? We can't tell because the animation will play at a constant rate.
        if (-dir < 0) d.flip();
        animator.SetTrigger(Return);

        yield return Utils.Frames(100);
        action = false;
        */
    }

    protected override IEnumerator specialG() //grounded special attack
    {
        //Two henchmen appear and shoot in the two cardinal directions
        //The mafia rat is in the middle; can still be damaged

        //Make henchmen objects with their own scripts. Activated when this func is called.
        // PARAMS
        action = true;
        animator.SetTrigger(Special_Ground);
        foreach (ParticleSystem vfx in groundedSpecialChargeVFX)
        {
            vfx.Play();
        }
        yield return Utils.Frames(60);
        foreach (ParticleSystem vfx in groundedSpecialChargeVFX)
        {
            vfx.Stop();
        }
        Projectile p = makeProjectile(0.3f * dir, 0f, 1.6f, 
            1.6f, 40, 20, 
            3f * dir, 0.5f, 5, 
            2, groundedSpecial); //How can we increase the range to make the jab a "shooting" action?
        p.setSpeedX(0.2f * dir); //Jerry will this increase the speed? We can't tell because the animation will play at a constant rate.
        p.transform.rotation = Quaternion.Euler(0, 0, 90);
        

        Projectile d = makeProjectile(0.3f * dir, 0f, 1.6f, 
            1.6f, 40, 20, 
            3f * -dir, 0.5f, 5, 
            2, groundedSpecial); //How can we increase the range to make the jab a "shooting" action?
        d.setSpeedX(0.2f * -dir); //Jerry will this increase the speed? We can't tell because the animation will play at a constant rate.
        d.transform.rotation = Quaternion.Euler(0, 0, -90);


        Projectile u = makeProjectile(0f, 0.3f * dir, 1.6f, 
            1.6f, 40, 20, 
            3f * dir, 0.5f, 5, 
            2, groundedSpecial); //How can we increase the range to make the jab a "shooting" action?
        u.setSpeedY(0.2f); //Jerry will this increase the speed? We can't tell because the animation will play at a constant rate.
       
        

        yield return Utils.Frames(40);
        action = false;
        animator.SetTrigger(Return);
    }

    protected override IEnumerator dash()
    {
        //Dash but knocked upwards

        // PARAMS
        const int setupDuration = 15;
        const int dashDuration = 10;
        const float setupSpeed = 0.04f;
        const float dashSpeed = 0.08f;
        
        action = true;
        animator.SetTrigger(Dash); 
        for (int i = 0; i < setupDuration; i++)
        {
            Transform myTransform = transform;
            Vector3 myPosition = myTransform.position;
            myPosition = new Vector3(myPosition.x + (setupSpeed * dir),
                myPosition.y,
                myPosition.z);
            myTransform.position = myPosition;
            yield return Utils.Frames(1);
        }
        makeHitbox(dir, 0, 4f,
                    3f, dashDuration, 70,
                    1f * dir, 1.6f, 20,
                    5);
        for (int i = 0; i < dashDuration; i++)
        {
            Transform myTransform = transform;
            Vector3 myPosition = myTransform.position;
            myPosition = new Vector3(myPosition.x + (dashSpeed * dir),
                myPosition.y,
                myPosition.z);
            myTransform.position = myPosition;
            yield return Utils.Frames(1);
        }
        yield return Utils.Frames(10);
        action = false;
        animator.SetTrigger(Return);
    }
    #endregion

    // -------------------------------------------------------------------------- UNITY EVENT FUNCTIONS
    #region UNITY EVENT FUNCTIONS
    #endregion

    // -------------------------------------------------------------------------- CASTING
    #region CASTING
    #endregion

    // -------------------------------------------------------------------------- HELPER CLASSES
    #region HELPER CLASSES
    #endregion
    
}
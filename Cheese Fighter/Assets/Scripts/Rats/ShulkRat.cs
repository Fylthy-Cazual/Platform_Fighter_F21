using System.Collections;
using UnityEngine;
// using System;

public class ShulkRat : Rat
{

    // -------------------------------------------------------------------------- STATIC MEMBERS
    #region STATIC MEMBERS
    private enum Buff { DAMAGE = 0, SPEED = 1, JUMP = 2 }
    #endregion

    // -------------------------------------------------------------------------- SERIALIZABLE INSPECTOR
    #region SERIALIZABLE INSPECTOR
    public ParticleSystem buffChargeVFX;
    public ParticleSystem buffReleaseVFX;
    public ParticleSystem[] buffVFX;
    #endregion

    // -------------------------------------------------------------------------- INSTANCE PROPERTIES
    #region INSTANCE PROPERTIES
    private float dmgmultiplier = 1;
    private bool buffOn = false;
    private int buffVal = 0;
    private ParticleSystem currBuffVFX;
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
        // PARAMS
        const float attackDuration = 0.5f;

        action = true;
        animator.SetTrigger(Jab_Ground);
        yield return Utils.Frames(20);
        for (float i = -0.3f; i < attackDuration; i += 0.05f) 
        {
            makeHitbox(0.6f * dir, -i, 8f, 
            1, 5, 2, 
            0.5f * dir, 0.5f, 1 * dmgmultiplier, 
            0);
            yield return Utils.Frames(1);
        }
        yield return Utils.Frames(10);
        action = false;
        animator.SetTrigger(Return);
    }

    protected override IEnumerator jabA() //aerial normal attack
    {
        action = true;
        animator.SetTrigger(Jab_Air);
        yield return Utils.Frames(15);
        makeHitbox(0, 1, 2, 
        8f, 15, 25, 
        0.5f, 1f * dir, 1 * dmgmultiplier, 
        0);
        yield return Utils.Frames(10);
        action = false;
        animator.SetTrigger(Return);
    }

    protected override IEnumerator specialG() //buff switch ability in replacement of special ground
    {
        action = true;
        //animator.SetTrigger(Special_Ground);
        yield return Utils.Frames(1);
        if (buffOn) {
            action = false;
            yield break;
        } else {
            StartCoroutine(buff(buffVal));
            action = false;
            yield break;
        }
    }

    protected IEnumerator buff(int type) 
    {
        buffOn = true;
        float originalSpeed = speed;
        float originalWeight = weight;
        int originalJumps = maxJumps;

        //animator.SetTrigger(Jab_Ground);
        Instantiate(buffChargeVFX, transform);
        yield return new WaitForSeconds(0.5f);
        Instantiate(buffReleaseVFX, transform);
        currBuffVFX = Instantiate(buffVFX[buffVal], transform);
        switch (type)
        {
            case (int)Buff.DAMAGE:
                dmgmultiplier *= 2;
                speed *= 0.75f;
                break;
            case (int)Buff.SPEED:
                speed *= 2;
                dmgmultiplier *= 0.75f;
                break;
            case (int)Buff.JUMP:
                maxJumps += 2;
                weight *= 0.75f;
                break;
        }
        yield return Utils.Frames(60);
        Debug.Log("HI");
        currBuffVFX.Stop();
        Debug.Log(currBuffVFX.isPlaying);
        animator.SetTrigger(Return);
        buffVal = (buffVal + 1) % 3;
        buffOn = false;
        dmgmultiplier = 1;
        weight = originalWeight;
        speed = originalSpeed;
        maxJumps = originalJumps;
    }

    protected override IEnumerator dash() 
    {
        // PARAMS
        const int setupDuration = 20;
        const int dashDuration = 25;
        const float setupSpeed = 0.04f;
        const float dashSpeed = 0.04f;
        const float attackDuration = 0.5f;
        
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

        for (float i = -0.3f; i < attackDuration; i += 0.05f) 
        {
            makeHitbox(0.6f * dir, i, 8f, 
            1, 5, 2, 
            0.5f * dir, 0.5f, 0.5f * dmgmultiplier, 
            0);
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


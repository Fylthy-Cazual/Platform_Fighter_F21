using System.Collections;
using UnityEngine;
// using System;

public class ShulkRat : Rat
{

    // -------------------------------------------------------------------------- STATIC MEMBERS
    #region STATIC MEMBERS
    #endregion

    // -------------------------------------------------------------------------- SERIALIZABLE INSPECTOR
    #region SERIALIZABLE INSPECTOR
    #endregion

    // -------------------------------------------------------------------------- INSTANCE PROPERTIES
    #region INSTANCE PROPERTIES
    public float dmgmultiplier = 1;
    public bool buffOn = false;
    public int buffVal = 0;
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
        //animator.SetTrigger(Jab_Ground);
        yield return Utils.Frames(20);
        for (float i = -0.3f; i < attackDuration; i += 0.05f) 
        {
            makeHitbox(0.6f * dir, -i, 8f, 
            1, 5, 1, 
            0.5f * dir, 0.5f, 1 * dmgmultiplier, 
            0);
            yield return Utils.Frames(1);
        }
        yield return Utils.Frames(10);
        action = false;
        //animator.SetTrigger(Return);
    }

    protected override IEnumerator jabA() //aerial normal attack
    {
        action = true;
        //animator.SetTrigger(Jab_Air);
        yield return Utils.Frames(15);
        makeHitbox(0, 1, 2, 
        8f, 15, 10, 
        0.5f, 1f * dir, 1 * dmgmultiplier, 
        0);
        yield return Utils.Frames(10);
        action = false;
        //animator.SetTrigger(Return);
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
        if (type == 0) {   //damage buff
            dmgmultiplier *= 2;
            speed *= 0.75f;
        }
        if (type == 1) {   //speed buff
            speed *= 2;
            dmgmultiplier *= 0.75f; 
        }
        if (type == 2) {   //jump buff
            maxJumps += 2;
            weight *= 0.75f;
        }
        yield return new WaitForSeconds(10);
        animator.SetTrigger(Return);
        buffVal = (buffVal + 1) % 3;
        buffOn = false;
        dmgmultiplier = 1;
        weight = originalWeight;
        speed = originalSpeed;
        maxJumps = originalJumps;
        yield break;
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
        //animator.SetTrigger(Dash); 
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
            1, 5, 1, 
            0.5f * dir, 0.5f, 0.5f * dmgmultiplier, 
            0);
            yield return Utils.Frames(1);
        }
        yield return Utils.Frames(10);
        action = false;
        //animator.SetTrigger(Return);
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


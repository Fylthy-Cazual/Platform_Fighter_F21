using System.Collections;
using UnityEngine;
// using System;

public class ShulkRat : Rat
{

    // -------------------------------------------------------------------------- STATIC MEMBERS
    #region STATIC MEMBERS
    private enum Buff { NONE = -1, DAMAGE = 0, SPEED = 1, JUMP = 2 }
    private const int framesPerBuff = 600;
    #endregion

    // -------------------------------------------------------------------------- SERIALIZABLE INSPECTOR
    #region SERIALIZABLE INSPECTOR
    public ParticleSystem buffChargeVFX;
    public ParticleSystem buffReleaseVFX;
    public ParticleSystem[] buffVFX;
    #endregion

    // -------------------------------------------------------------------------- INSTANCE PROPERTIES
    #region INSTANCE PROPERTIES
    private int buffVal = 0;
    private Buff currBuff = Buff.NONE;
    private int currBuffFrames;
    private ParticleSystem currBuffVFX;

    private float damageMultiplier = 1;
    private int baseJumps;
    private float baseSpeed;
    private float baseWeight;
    #endregion

    // -------------------------------------------------------------------------- GETTERS AND SETTERS
    #region GETTERS AND SETTERS
    #endregion

    // -------------------------------------------------------------------------- INITIALIZATION
    #region INITIALIZATION
    #endregion

    // -------------------------------------------------------------------------- METHODS AND ROUTINES
    #region METHODS AND ROUTINES
    public override void Start()
    {
        base.Start();

        baseJumps = maxJumps;
        baseSpeed = speed;
        baseWeight = weight;
    }

    public override void Update()
    {
        base.Update();

        if (currBuff != Buff.NONE)
        {
            currBuffFrames -= 1;
            if (currBuffFrames <= 0)
            {
                currBuffVFX.Stop();
                currBuff = Buff.NONE;
            }
        }
        switch (currBuff)
        {
            case Buff.NONE:
                SetStats(1, 0, 1, 1);
                break;
            case Buff.DAMAGE:
                SetStats(2, 0, 0.75f, 1);
                break;
            case Buff.SPEED:
                SetStats(0.75f, 0, 2, 1);
                break;
            case Buff.JUMP:
                SetStats(1, 2, 1, 0.75f);
                break;
        }
    }

    private void SetStats(float damageMultiplier, int additionalJumps, float speedMultiplier, float weightMultiplier)
    {
        this.damageMultiplier = damageMultiplier;
        maxJumps = baseJumps + additionalJumps;
        speed = baseSpeed * speedMultiplier;
        weight = baseWeight * weightMultiplier;
    }

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
            0.5f * dir, 0.5f, 1 * damageMultiplier, 
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
        0.5f, 1f * dir, 1 * damageMultiplier, 
        0);
        yield return Utils.Frames(10);
        action = false;
        animator.SetTrigger(Return);
    }

    protected override IEnumerator specialG() //buff switch ability in replacement of special ground
    {
        //animator.SetTrigger(Special_Ground);
        yield return Utils.Frames(0);
        if (currBuff == Buff.NONE && !action) {
            action = true;
            StartCoroutine(buff(buffVal));
            buffVal = (buffVal + 1) % 3;
        }
    }

    protected IEnumerator buff(int type) 
    {
        //animator.SetTrigger(Jab_Ground);
        Instantiate(buffChargeVFX, transform);
        yield return new WaitForSeconds(0.5f);
        Instantiate(buffReleaseVFX, transform);
        currBuffVFX = Instantiate(buffVFX[type], transform);
        currBuffFrames = framesPerBuff;
        switch (type)
        {
            case 0:
                currBuff = Buff.DAMAGE;
                break;
            case 1:
                currBuff = Buff.SPEED;
                break;
            case 2:
                currBuff = Buff.JUMP;
                break;
        }
        action = false;
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
            0.5f * dir, 0.5f, 0.5f * damageMultiplier, 
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


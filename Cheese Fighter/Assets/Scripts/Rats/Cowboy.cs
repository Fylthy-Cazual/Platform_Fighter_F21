using System.Collections;
using UnityEngine;

public class Cowboy : Rat
{

    // -------------------------------------------------------------------------- STATIC MEMBERS
    #region STATIC MEMBERS
    #endregion

    // -------------------------------------------------------------------------- SERIALIZABLE INSPECTOR
    #region SERIALIZABLE INSPECTOR
    public Projectile groundedNormal;
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
        yield return Utils.Frames(25);
        Projectile p = makeProjectile(0.3f * dir, 0f, 1.6f, 
            5f, 60, 10, 
            1.5f * dir, 0.5f, 5, 
            2, groundedNormal);
        p.setSpeedX(0.1f * dir);
        if (dir < 0) p.flip();
        action = false;
        animator.SetTrigger(Return);
    }

    protected override IEnumerator jabA() //aerial normal attack
    {

        // PARAMS
        const int setupDuration = 28;
        const int dashDuration = 3;
        const float setupSpeed = 0.1f;
        const float dashSpeed = 0.1f;

        action = true;
        animator.SetTrigger(Jab_Air);
        for (int i = 0; i < setupDuration; i++)
        {
            Transform myTransform = transform;
            Vector3 myPosition = myTransform.position;
            myPosition = new Vector3(myPosition.x,
                myPosition.y + setupSpeed,
                myPosition.z);
            myTransform.position = myPosition;
            yield return Utils.Frames(1);
        }
        
        while (!collidingY) {
            makeHitbox(0, 0, 4f,
                3f, dashDuration, 10,
                1 * dir, 1.4f, 30,
                5);

            for (int i = 0; i < dashDuration; i++)
            {
                Transform myTransform = transform;
                Vector3 myPosition = myTransform.position;
                myPosition = new Vector3(myPosition.x,
                    myPosition.y - dashSpeed,
                    myPosition.z);
                myTransform.position = myPosition;
                yield return Utils.Frames(1);
            }
        }
        
        animator.SetTrigger(Return);

        yield return Utils.Frames(10);
        action = false;
    }

    protected override IEnumerator specialG() //grounded special attack
    {
        // PARAMS
        const int setupDuration = 20;
        const int dashDuration = 40;
        const float setupSpeed = 0.06f;
        const float dashSpeed = 0.15f;
        
        action = true;
        animator.SetTrigger(Special_Ground); 
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
        makeHitbox(0, 0, 4f,
            3f, dashDuration, 20,
            2f * dir, 3.2f, 40,
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
        yield return Utils.Frames(3);
        action = false;
        animator.SetTrigger(Return);
    }

    protected override IEnumerator dash()
    {
        // PARAMS
        const int setupDuration = 10;
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
        makeHitbox(0, 0, 4f,
                    3f, dashDuration, 40,
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
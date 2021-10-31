using System.Collections;
using UnityEngine;

public class Cowboy : Rat
{
    
    protected override IEnumerator jabG() //grounded normal attack
    {
        action = true;
        animator.SetTrigger(Jab_Ground);
        for (int i = 0; i < 25; i++)
        {
            yield return Utils.Frames(1);
        }
        Projectile p = makeProjectile(0.3f * dir, 0f, 1.6f, 
            5f, 15, 10, 
            3 * dir, 1, 5, 
            2);
        p.setSpeedX(0.1f * dir);
        if (dir < 0) {
            p.flip();
            Debug.Log("flip");
        }
        for (int i = 0; i < 5; i++)
        {
            yield return Utils.Frames(1);
        }
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
                3f, dashDuration, 40,
                5 * dir, 4, 30,
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

        yield return Utils.Frames(30);
        action = false;
    }

    protected override IEnumerator specialG() //grounded special attack
    {
        // PARAMS
        const int setupDuration = 20;
        const int dashDuration = 40;
        const float setupSpeed = 0.04f;
        const float dashSpeed = 0.05f;
        
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
            3f, dashDuration, 60,
            5 * dir, 8, 40,
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
        yield return Utils.Frames(14);
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
                    5 * dir, 8, 20,
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
        yield return Utils.Frames(14);
        action = false;
        animator.SetTrigger(Return);
    }
}

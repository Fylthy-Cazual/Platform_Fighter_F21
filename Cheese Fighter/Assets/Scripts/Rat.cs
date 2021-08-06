using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public float hp;
    public float speed;
    public float weight;
    public int jumps;
    public int maxJumps;
    public int dir = 1;

    public Animator animator;

    public Rigidbody2D rb;
    public bool action; //True if Player is performing an action, False otherwise.

    public Hitbox hitboxInstance;
    public JumpRing jr;
    public Trail trail;

    //Experimental stuff
    private bool collidingX;
    private bool collidingY;

    // Start is called before the first frame update
    public void Start()
    {
        speed = speed / 50f;
        jumps = maxJumps;

        animator = gameObject.GetComponent<Animator>();

        rb = gameObject.GetComponent<Rigidbody2D>();
        action = false;

        collidingX = false;
        collidingY = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!action)
        {
            if (Input.GetKeyDown(KeyCode.W)) //Jump
            {
                startJump();
            }

            if (Input.GetKey(KeyCode.D)) //Move Right
            {
                right();
            }
            else if (Input.GetKey(KeyCode.A)) //Move Left
            {
                left();
            }
            else //No horizontal movement
            {
                animator.SetFloat("Speed", 0f);
            }

            if(Input.GetKeyDown(KeyCode.J))
            {
                jab();
            }
        }
    }

    #region movement

    public void right()
    {
        dir = 1;
        animator.SetFloat("Speed", 1f);
        animator.SetFloat("Dir", 1f);
        transform.position = new Vector3(transform.position.x + speed,
                                transform.position.y,
                                transform.position.z);
    }

    public void left()
    {
        dir = -1;
        animator.SetFloat("Speed", -1f);
        animator.SetFloat("Dir", -1f);
        transform.position = new Vector3(transform.position.x - speed,
                                transform.position.y,
                                transform.position.z);
    }

    public void startJump()
    {
        if (jumps > 0)
        {
            StartCoroutine(jump());
            jumps--;
            JumpRing newJR = Instantiate(jr);
            newJR.transform.position = transform.position;
        }
    }

    IEnumerator jump()
    {
        animator.SetFloat("Air", 1f);
        for (int i = 0; i < 15; i++)
        {
            transform.position = new Vector3(transform.position.x,
                                            transform.position.y + ((30f - i)/200),
                                            transform.position.z);
            rb.velocity = new Vector3(0f, 0f, 0f);
            yield return Utils.Frames(1);
        }
        animator.SetFloat("Air", -1f);
    }

    #endregion

    #region attack

    public void jab()
    {
        if (rb.velocity.y == 0f && jumps == maxJumps) //Player is grounded
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) //Left or Right is held
            {
                StartCoroutine(dash());
            }
            else
            {
                StartCoroutine(jabG());
            }
        }
        else //Player is airborne
        {
            StartCoroutine(jabA());
        }
    }

    IEnumerator jabG()
    {
        action = true;
        animator.SetTrigger("Jab-Ground");
        yield return Utils.Frames(3);
        makeHitbox(0.3f * dir, 0f, 1f, 
                    0.4f, 5, 10, 
                    3 * dir, 1, 5, 
                    2);
        yield return Utils.Frames(7);
        action = false;
        animator.SetTrigger("Return");
    }

    IEnumerator jabA()
    {
        action = true;
        animator.SetTrigger("Jab-Air");
        for (int i = 0; i < 24; i++)
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
            yield return Utils.Frames(1);
        }

        makeHitbox(0.4f * dir, -0.2f, 5f,
                    4f, 20, 100,
                    2f * dir, -6f, 30,
                    10);
        for (int i = 0; i < 24; i++) 
        {
            transform.position = new Vector3(transform.position.x + (0.1f * dir),
                                            transform.position.y - 0.05f,
                                            0f);
            yield return Utils.Frames(1);
        }
        yield return Utils.Frames(4);
        action = false;
        animator.SetTrigger("Return");
    }

    IEnumerator dash()
    {
        action = true;
        animator.SetTrigger("Dash"); 
        for (int i = 0; i < 20; i++)
        {
            transform.position = new Vector3(transform.position.x + (0.04f * dir),
                                transform.position.y,
                                transform.position.z);
            yield return Utils.Frames(1);
        }
        makeHitbox(0, 0, 4f,
                    3f, 27, 40,
                    5 * dir, 8, 20,
                    5);
        for (int i = 0; i < 27; i++)
        {
            transform.position = new Vector3(transform.position.x + (0.1f * dir),
                                transform.position.y,
                                transform.position.z);
            yield return Utils.Frames(1);
        }
        yield return Utils.Frames(14);
        action = false;
        animator.SetTrigger("Return");
    }

    public void makeHitbox(float xPos, float yPos, float width, 
                            float height, int duration, float damage,
                            float xLaunch, float yLaunch, float hitstun,
                            float blockstun)
    {
        Hitbox hbox = Instantiate(hitboxInstance);
        hbox.setHitbox(this.transform, gameObject.tag, xPos, yPos, width, 
                        height, duration, damage, xLaunch, yLaunch,
                        hitstun, blockstun);
    }

    #endregion

    #region hit

    public void takeDmg(float dmg)
    {
        hp += dmg;

    }

    public void launch(float x, float y)
    {
        float factor = Mathf.Log(hp, 2) * 7f;
        rb.AddForce(new Vector3(x * factor, y * factor, 0f));
    }

    public void launch2(float x, float y)
    {
        StartCoroutine(launch2num(x, y));
    }

    IEnumerator launch2num(float x, float y)
    {
        float factor = (Mathf.Log(hp, 2) * 7f) * 0.75f;
        rb.AddForce(new Vector3(x * factor, y * factor, 0f));
        factor = 1f + (hp/50);
        for (int i = 0; i < 15; i++)
        {
            // Trail newTrail = Instantiate(trail);
            // newTrail.transform.position = transform.position;
            transform.position = new Vector3(transform.position.x + (x * factor/100),
                                            transform.position.y + (y * factor/100),
                                            0f);
            yield return Utils.Frames(1);
            if (collidingX && i > 1)
            {
                x *= -1;
                collidingX = false;
                //Debug.Log("bounce X");
            }
            if (collidingY && i > 1)
            {
                y *= -1;
                collidingY = false;
                //Debug.Log("bounce Y");
            }
        }
        factor = (Mathf.Log(hp, 2) * 7f) * 0.75f;
        rb.AddForce(new Vector3(x * factor, 0f, 0f));
    }

    public void addstun(int stun)
    {
        StopAllCoroutines();
    }

    IEnumerator stunned(int stun)
    {
        action = true;
        //Set stun animation
        yield return Utils.Frames(stun);
        action = false;
    }

    #endregion

    public void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            collidingY = true;
            if (!action && rb.velocity.y == 0f && col.transform.position.y < transform.position.y)
            {
                animator.SetFloat("Air", 0f);
                jumps = maxJumps;
            }
        }
        else if (col.gameObject.tag == "Wall")
        {
            collidingX = true;
        }
        else if (col.gameObject.tag[0] == 'p')
        {
            animator.SetFloat("Air", 0f);
            if (!action)
            {
                
                jumps = maxJumps;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            if (!action && col.transform.position.y < transform.position.y)
            {
                animator.SetTrigger("Return");
                StopAllCoroutines();
            }
        }
    }

    public void OnCollisionExit2D(Collision2D col)
    {
        collidingX = false;
        collidingY = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rat : MonoBehaviour
{
    
    #region STATIC READONLY CONST
    public static readonly float SPEED_FACTOR = 1f / 50f;
    #endregion
    
    #region Animator Frames
    public static readonly int Return = Animator.StringToHash("Return");
    public static readonly int Speed = Animator.StringToHash("Speed");
    public static readonly int Dir = Animator.StringToHash("Dir");
    public static readonly int Air = Animator.StringToHash("Air");
    public static readonly int Jab_Ground = Animator.StringToHash("Jab-Ground");
    public static readonly int Jab_Air = Animator.StringToHash("Jab-Air");
    public static readonly int Special_Ground = Animator.StringToHash("Special-Ground");
    public static readonly int Special_Air = Animator.StringToHash("Special-Air");
    public static readonly int Dash = Animator.StringToHash("Dash");
    #endregion
    
    #region Serializable Properties
    public new string name;
    public float hp;
    public float speed;
    public float weight;
    public int maxJumps;
    public int dir = 1;
    #endregion
    
    #region Serializable References
    public SpriteRenderer sr;
    public int lives = 3;
    public int playerNum;
    public Vector3[] respawnPos;
    //Transform mTextOverTransform >>>>>>> origin/arik_and_adith:Cheese Fighter/Assets/Scripts/Rat.cs
    public Hitbox hitboxInstance;
    public Projectile projectileInstance;
    public JumpRing jr;
    public Trail trail;
    #endregion
    
    #region Inspectorless Fields
    [HideInInspector] public int jumps;
    [HideInInspector] public Animator animator;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public bool action; //True if Player is performing an action, False otherwise.
    [HideInInspector] public bool isJumping;
    protected bool collidingX;
    protected bool collidingY;
    protected TextMesh textMesh;
    #endregion

    private UnityManager UM;

    // Start is called before the first frame update
    public void Start()
    {
        speed = speed * SPEED_FACTOR;
        jumps = maxJumps;
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        action = false;
        isJumping = false;
        collidingX = false;
        collidingY = false;
        animator.SetFloat(Speed, 0f);
        animator.SetFloat(Dir, 1f);
        textMesh = UIManager.Instance.AttachText(transform, Vector2.up * 1);
        textMesh.text = "Player " + playerNum;
        textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.alignment = TextAlignment.Center;
        textMesh.characterSize = 0.5f;
        respawnPos = new []
        {
            new Vector3((float)-2.5,3), 
            new Vector3((float)-0.5,3), 
            new Vector3((float)1.5,3), 
            new Vector3((float)3.5,3)
        };
    }

    // Update is called once per frame
    public void Update()
    {
        textMesh.text = "P" + playerNum + " " + hp + "%";
        if (!action)
        {
            if (playerNum == 0) {
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

                if (Input.GetKeyDown(KeyCode.Z))
                {
                    jab();
                }
                else if (Input.GetKeyDown(KeyCode.X))
                {
                    special();
                }
            } else if (playerNum == 1) {
                if (Input.GetKeyDown(KeyCode.UpArrow)) //Jump
                {
                    startJump();
                }

                if (Input.GetKey(KeyCode.RightArrow)) //Move Right
                {
                    right();
                }
                else if (Input.GetKey(KeyCode.LeftArrow)) //Move Left
                {
                    left();
                }
                else //No horizontal movement
                {
                    animator.SetFloat("Speed", 0f);
                }

                if (Input.GetKeyDown(KeyCode.Comma))
                {
                    jab();
                }
                else if (Input.GetKeyDown(KeyCode.Period))
                {
                    special();
                }

            }    
        }
    }

    public void die() 
    {
        lives -= 1;
        transform.position = respawnPos[playerNum];
        rb.velocity = Vector2.zero;
        hp = 0; 
        StopAllCoroutines();
        action = false;
        isJumping = false;
        animator.SetTrigger(Return);
        if (lives == 0) 
        {
            GameplayManager.Instance.DecideVictor();
        }
    }

    #region movement

    public bool isGrounded() => rb.velocity.y == 0f && jumps == maxJumps;

    public void right()
    {
        dir = 1;
        animator.SetFloat(Speed, 1f);
        animator.SetFloat(Dir, 1f);
        transform.position += speed * Vector3.right;
        sr.flipX = false;
    }

    public void left()
    {
        dir = -1;
        animator.SetFloat(Speed, 1f);
        animator.SetFloat(Dir, -1f);
        transform.position += speed * Vector3.left;
        sr.flipX = true;
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
        animator.SetFloat(Air, 1f);
        isJumping = true;
        for (int i = 0; i < 15; i++)
        {
            transform.position += (30f - i) / 200 * Vector3.up;
            rb.velocity = new Vector3(0f, 0f, 0f);
            yield return Utils.Frames(1);
        }
        isJumping = false;
        animator.SetFloat(Air, -1f);
    }

    #endregion

    #region attack

    public void jab()
    {
        if (isGrounded()) //Player is grounded
        {
            if ((playerNum == 0 && Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) || 
                (playerNum == 1 && Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))) //Left or Right is held
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

    public void special()
    {
        if (isGrounded())
        {
            StartCoroutine(specialG());
        }
        else
        {
            StartCoroutine(specialA());
        }
    }

    protected virtual IEnumerator jabG() //grounded normalk attack
    {
        action = true;
        animator.SetTrigger(Jab_Ground);
        yield return Utils.Frames(3);
        makeHitbox(0.3f * dir, 0f, 1f, 
                    0.4f, 5, 10, 
                    3 * dir, 1, 5, 
                    2);
        yield return Utils.Frames(7);
        action = false;
        animator.SetTrigger(Return);
    }

    protected virtual IEnumerator jabA() //aerial normal attack
    {
        action = true;
        animator.SetTrigger(Jab_Air);
        for (int i = 0; i < 24; i++)
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
            yield return Utils.Frames(1);
        }

        makeHitbox(0.4f * dir, -0.2f, 5f,
                    4f, 20, 100,
                    2f * dir, -6f, 30,
                    10);
        yield return Utils.VelocityFrames(transform, new Vector3(0.1f * dir, -0.05f, 0f), 24);
        yield return Utils.Frames(4);
        action = false;
        animator.SetTrigger(Return);
    }

    protected virtual IEnumerator specialG() //grounded special attack
    {
        action = true;
        animator.SetTrigger(Special_Ground);
        yield return Utils.Frames(25);
        Projectile p = makeProjectile(0.3f * dir, 0f, 1.6f, 
                    5f, 15, 10, 
                    3 * dir, 1, 5, 
                    2);
        p.setSpeedX(0.1f * dir);
        if (dir < 0) {
            p.flip();
            Debug.Log("flip");
        }
        yield return Utils.Frames(5);
        action = false;
        animator.SetTrigger(Return);
    }

    protected virtual IEnumerator specialA() //arial special attack
    {
        return specialG();
    }

    protected virtual IEnumerator dash()
    {
        action = true;
        animator.SetTrigger(Dash);
        yield return Utils.VelocityFrames(transform, new Vector2(0.04f * dir, 0), 20);
        makeHitbox(0, 0, 4f,
                    3f, 27, 40,
                    5 * dir, 8, 20,
                    5);
        yield return Utils.VelocityFrames(transform, new Vector2(0.1f * dir, 0), 27);
        yield return Utils.Frames(14);
        action = false;
        animator.SetTrigger(Return);
    }

    public Hitbox makeHitbox(float xPos, float yPos, float width, 
                            float height, int duration, float damage,
                            float xLaunch, float yLaunch, float hitstun,
                            float blockstun)
    {
        Hitbox hbox = Instantiate(hitboxInstance);
        hbox.setHitbox(this.transform, gameObject.tag, xPos, yPos, width, 
                        height, duration, damage, xLaunch, yLaunch,
                        hitstun, blockstun);
        return hbox;
    }

    public Projectile makeProjectile(float xPos, float yPos, float width, 
                            float height, int duration, float damage,
                            float xLaunch, float yLaunch, float hitstun,
                            float blockstun)
    {
        Projectile proj = Instantiate(projectileInstance);
        proj.setHitbox(this.transform, gameObject.tag, xPos, yPos, width, 
                        height, duration, damage, xLaunch, yLaunch,
                        hitstun, blockstun);
        return proj;
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
            Vector3 newPos = new Vector3(transform.position.x + (x * factor/100),
                transform.position.y + (y * factor/100),
                0f);
            if (Physics2D.Linecast(transform.position, newPos, LayerMask.GetMask("Wall")))
            {
                x *= -1;
            }
            else if (Physics2D.Linecast(transform.position, newPos, LayerMask.GetMask("Platform")))
            {
                y *= -1;
            }
            else
            {
                transform.position = newPos;
            }
            yield return Utils.Frames(1);
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
        if (col.gameObject.CompareTag("Platform"))
        {
            collidingY = true;
            if (!action && rb.velocity.y == 0f && col.transform.position.y < transform.position.y)
            {
                animator.SetFloat(Air, 0f);
                jumps = maxJumps;
            }
        }
        else if (col.gameObject.CompareTag("Wall"))
        {
            collidingX = true;
        }
        else if (col.gameObject.tag[0] == 'p')
        {
            animator.SetFloat(Air, 0f);
            if (!action)
            {
                
                jumps = maxJumps;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Platform"))
        {
            if (!action && col.transform.position.y < transform.position.y)
            {
                //Debug.Log("calling");
                //animator.SetTrigger(Return);
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

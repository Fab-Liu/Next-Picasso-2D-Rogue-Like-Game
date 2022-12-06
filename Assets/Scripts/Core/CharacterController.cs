using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    // Components
    [Header("Components")]

    [SerializeField]
    protected LayerMask Ground;

    [SerializeField]
    protected Transform GroundCheck;

    [SerializeField]
    protected Animator myAnimator;

    [SerializeField]
    protected Collider2D myCollider;

    [SerializeField]
    protected Rigidbody2D myRigidbody2D;

    [SerializeField]
    public AudioSource mySoundSource;



    // Paramaters
    [Header("Paramaters")]
    public float speed = 450.0f;
    public float walkSpeed = 450.0f;
    public float runSpeed = 800.0f;
    public float jumpForce = 639.7f;
    public float dashSpeed = 1500.0f;


    public float moveVertical;
    public float moveHorizontal;
    public float faceDirection;
    public float faceLastPosition = 1;


    public float dashLast;
    public float dashTime;

    public float dashTimeLeft;
    public float dashCoolDown;

    public float hurt = 0.5f;
    public float hurtTimeLeft;


    // States
    [Header("States")]
    public bool isHurt;
    public bool isDuck;
    public bool isJump;
    public bool isGround;
    public bool isDashing;


    public int jumpCount;
    public bool jumpPressed;


    // Skill
    [Header("Skills")]
    public Image dashImage;


    // Start is called before the first frame update
    void Start()
    {
        ParameterInit();

        myAnimator = GetComponent<Animator>();
        mySoundSource = GetComponent<AudioSource>();

        myCollider = GetComponent<Collider2D>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterJumpPressed();
        CharacterDashPressed();
        CharacterDuckPressed();

        // CharacterShoot();

        CharacterDashCoolDown();
    }

    void FixedUpdate()
    {
        CharacterCheckGround();
        CharacterHurtCheck();
        CharacterIdleCheck();
        CharacterAnimation();
    }

    private void ParameterInit()
    {
        speed = 450.0f;
        walkSpeed = 450.0f;
        runSpeed = 800.0f;
        jumpForce = 639.7f;


        dashTime = (float)0.35;
        dashLast = -100;
        dashSpeed = 1400;
        dashCoolDown = 2;

        faceLastPosition = -1;
    }


    private void CharacterCheckGround()
    {
        isGround = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, Ground);
    }

    private void CharacterHurtCheck()
    {
        if (!isHurt)
        {
            CharacterDash();
            if (isDashing) return;

            CharacterDuck();

            CharacterMove();
            CharacterRun();

            CharacterFlip();
            CharacterJump();
        }
    }

    private void CharacterIdleCheck()
    {
        if (moveHorizontal == 0 && isGround)
        {
            myAnimator.SetBool("Idle", true);
            myAnimator.SetBool("Run", false);
            myAnimator.SetBool("Walk", false);
        }
        else
        {
            myAnimator.SetBool("Idle", false);
        }
    }

    private void CharacterMove()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        myRigidbody2D.velocity =
            new Vector2(moveHorizontal * speed * Time.fixedDeltaTime,
                myRigidbody2D.velocity.y);

        if (moveHorizontal != 0)
        {
            faceLastPosition = moveHorizontal;
        }

        myAnimator.SetBool("Walk", Mathf.Abs(moveHorizontal) != 0);
    }

    private void CharacterRun()
    {
        // with shift to run
        if (Input.GetKey(KeyCode.LeftShift) && isJump == false)
        {
            speed = runSpeed;
            myAnimator.SetBool("Run", true);
            myAnimator.SetBool("Idle", false);
        }
        else
        {
            speed = walkSpeed;
            myAnimator.SetBool("Run", false);
            myAnimator.SetBool("Walk", true);
            myAnimator.SetBool("Idle", false);
        }
    }


    private void CharacterFlip()
    {
        faceDirection = Input.GetAxisRaw("Horizontal");
        if (faceDirection > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (faceDirection < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void CharacterJump()
    {
        if (isGround && Mathf.Abs(myRigidbody2D.velocity.y) < 0.01f)
        {
            jumpCount = 2;
            isJump = false;
        }

        if (jumpPressed)
        {
            if (isGround)
            {
                isJump = true;
                myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x,
                        jumpForce * Time.deltaTime);

                jumpCount -= 1;
                jumpPressed = false;
            }
            else if (jumpCount > 0 && isJump)
            {
                myRigidbody2D.velocity =
                    new Vector2(myRigidbody2D.velocity.x,
                        jumpForce * (float)1.2 * Time.deltaTime);

                jumpCount -= 1;
                jumpPressed = false;
            }
            else if (jumpCount == 0)
            {
                jumpPressed = false;
            }
            else
            {
                jumpPressed = false;
            }

            // jumpPressed = false;
            // myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpForce * Time.fixedDeltaTime);
            // jumpCount++;
        }
    }

    private void CharacterJumpPressed()
    {
        if ((Input.GetButtonDown("Jump")) && jumpCount > 0)
        {
            jumpPressed = true;
        }
    }

    private void CharacterDash()
    {
        if (isDashing)
        {
            if (dashTimeLeft > 0)
            {
                myRigidbody2D.velocity = new Vector2(moveHorizontal * dashSpeed * Time.fixedDeltaTime, 0);
                dashTimeLeft -= Time.deltaTime;
                ShadowPool.instance.GetFromPool();
            }
            else
            {
                isDashing = false;
            }
        }
    }

    private void CharacterDashPressed()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (Time.time >= (dashLast + dashCoolDown))
            {
                isDashing = true;
                dashTimeLeft = dashTime;
                dashLast = Time.time;
                dashImage.fillAmount = 1;
            }
        }
    }

    private void CharacterDuck()
    {
        // ctrl for duck 
        // if (isDuck)
        // {
        //     // speed = 200.0f;
        //     myAnimator.SetBool("Duck", true);
        // }
        // else
        // {
        //     myAnimator.SetBool("Duck", false);
        // }
    }


    private void CharacterDuckPressed()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isDuck = true;
            // myAnimator.SetBool("Duck", true);

            // myAnimator.SetBool("Duck", true);
            // myCollider.offset = new Vector2(0, -0.5f);
            // myCollider.size = new Vector2(1, 1.5f);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isDuck = false;
            // myAnimator.SetBool("Duck", false);

            // myAnimator.SetBool("Duck", false);
            // myCollider.offset = new Vector2(0, 0);
            // myCollider.size = new Vector2(1, 2);
        }
    }

    private void CharacterAnimation()
    {
        myAnimator.SetBool("Idle", true);

        if (isGround)
        {
            myAnimator.SetBool("JumpUp", false);
            myAnimator.SetBool("JumpDown", false);
        }
        else if (!isGround && myRigidbody2D.velocity.y > 0)
        {
            myAnimator.SetBool("JumpUp", true);
            myAnimator.SetBool("JumpDown", false);
        }
        else if (!isGround && myRigidbody2D.velocity.y < 0)
        {
            myAnimator.SetBool("JumpDown", true);
            myAnimator.SetBool("JumpUp", false);
            myAnimator.SetBool("Idle", true);
        }

        if (isDuck)
        {
            myAnimator.SetBool("Duck", true);
        }
        else
        {
            myAnimator.SetBool("Duck", false);
        }

        if (isHurt)
        {
            if (Time.time - hurtTimeLeft >= hurt)
            {
                hurtTimeLeft = 0;
                isHurt = false;
                myAnimator.SetBool("Hurt", false);
            }
        }
    }

    private void CharacterDashCoolDown()
    {
        dashImage.fillAmount -= 1.0f / dashCoolDown * Time.deltaTime;
    }
}

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
    public AudioSource mySoundSource;

    [SerializeField]
    protected Animator myAnimator;

    [SerializeField]
    protected Collider2D myCollider;

    [SerializeField]
    protected Rigidbody2D myRigidbody2D;

    [SerializeField]
    protected LayerMask Ground;

    [SerializeField]
    protected Transform GroundCheck;


    // Paramaters
    [Header("Paramaters")]
    public float speed = 240.0f;
    public float runSpeed = 500.0f;
    public float dashSpeed;
    public float jumpForce = 439.7f;


    public float faceDirection;
    public float faceLastPosition = 1;


    public float moveVertical;
    public float moveHorizontal;


    public float dashLast;
    public float dashTime;
    public float dashTimeLeft;
    public float dashCoolDown;

    // States
    [Header("States")]
    public bool isHurt;
    public bool isJump;
    public bool isGround;
    public bool isDashing;


    public int jumpCount;
    public bool jumpPressed;


    // Start is called before the first frame update
    void Start()
    {
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

        CharacterShoot();
    }

    void FixedUpdate()
    {
        CharacterCheckGround();

        CharacterMove();
        CharacterRun();
        CharacterFlip();
        CharacterJump();
    }

    private void CharacterCheckGround()
    {
        isGround = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, Ground);
    }

    private void CharacterMove()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        myRigidbody2D.velocity =
            new Vector2(moveHorizontal * speed * Time.fixedDeltaTime,
                myRigidbody2D.velocity.y);

        if (moveHorizontal != 0)
        {
            faceLastPosition = moveHorizontal;
        }
    }

    private void CharacterRun()
    {
        // with shift to run
        if (Input.GetKey(KeyCode.LeftShift) && isJump == false)
        {
            speed = runSpeed;
        }
        else
        {
            speed = 240.0f;
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
        if (Input.GetKeyDown(KeyCode.Space) && isJump == false)
        {
            jumpPressed = true;
        }
        if (jumpPressed)
        {
            jumpPressed = false;
            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpForce * Time.fixedDeltaTime);
            jumpCount++;
        }
    }

    private void CharacterJumpPressed()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isJump == false)
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
                myRigidbody2D.velocity = new Vector2(moveHorizontal * Time.fixedDeltaTime, 0);
                dashTimeLeft -= Time.deltaTime;
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
            }
        }
    }

    private void CharacterShoot()
    {
    }
}

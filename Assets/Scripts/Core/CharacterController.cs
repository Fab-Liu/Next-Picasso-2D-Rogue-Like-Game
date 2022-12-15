using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public float jumpForce = 850f;

    public float dashSpeed = 1500.0f;

    public float moveVertical;

    public float moveHorizontal;

    public float faceDirection;

    public float faceLastPosition = 1;

    public float dashLast;

    public float dashTime;

    public float dashTimeLeft;

    public float dashCoolDown;

    public float hurt = 1f;

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
    public Image skillImage;
    public Image skillImage2;
    public Image skillImage3;
    public Image skillImage4;
    public Image skillImage5;

    // Weapon

    [Header("Weapon Parameter")]

    public float BulletCoolDown = 0.35f;
    public GameObject bulletPrefab; //发射子弹

    [Header("Magic Parameter")]
    public float MagicCoolDown1 = 2.0f;
    public float MagicCoolDown2 = 1.0f;
    public float MagicCoolDown3 = 1.0f;
    public float MagicCoolDown4 = 5.0f;

    [Header("Hammer and hand")]
    public GameObject hammer;
    public GameObject hand;
    public GameObject Shield;

    private PlayerHealth health;

    private bool isShield = false;
    private float shieldTime = 0;

    [Header("Points")]
    public Transform p1;
    public Transform p2;

    [Header("Dialogs")]
    public GameObject dialog1;
    public GameObject dialog2;


    private float dialogTimer;
    private bool showD1 = false;
    private bool showD2 = false;

    // 声音
    //音源AudioSource相当于播放器，而音效AudioClip相当于磁带
    public AudioSource music;
    public AudioClip hurtAudio;//这里我要给主角添加跳跃的音效
    public AudioClip jump;
    public AudioClip run;
    public AudioClip walk;
    public AudioClip m1;
    public AudioClip m2;
    public AudioClip m3;

    public magic_inc p;

    private Cinemachine.CinemachineCollisionImpulseSource MyInpulse;

    // Start is called before the first frame update
    void Start()
    {
        //给对象添加一个AudioSource组件
        music = gameObject.AddComponent<AudioSource>();
        //设置不一开始就播放音效
        music.playOnAwake = false;
        //设置音量大小
        music.volume = 0.2f;

        MyInpulse = GetComponent<Cinemachine.CinemachineCollisionImpulseSource>();

        myAnimator = GetComponent<Animator>();
        mySoundSource = GetComponent<AudioSource>();

        myCollider = GetComponent<Collider2D>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        p = GetComponent<magic_inc>();

        health = GetComponent<PlayerHealth>();

        Shield.SetActive(false);

        CharacterInit();
        ParameterInit();
        Time.timeScale = 0f;

        hurtAudio = Resources.Load<AudioClip>("Sound/hurt_audio");
        jump = Resources.Load<AudioClip>("Sound/Jump");
        walk = Resources.Load<AudioClip>("Sound/Walk");
        run = Resources.Load<AudioClip>("Sound/Run");
        m1 = Resources.Load<AudioClip>("Sound/Magic_wind");
        m2 = Resources.Load<AudioClip>("Sound/Magic_stone");
        m3 = Resources.Load<AudioClip>("Sound/Magic_3");
    }

    // Update is called once per frame
    void Update()
    {
        CharacterJumpPressed();
        CharacterDashPressed();
        CharacterDuckPressed();

        CharacterDiePressed();
        CharacterRevivePressed();

        // CharacterShoot();
        CharacterDashCoolDown();
        HandleInput();
        ReleaseMagic();

        CheckDialog();

        if (isShield && Time.time - shieldTime > 3)
        {
            Shield.SetActive(false);
            isShield = false;
            shieldTime = 0;
        }

    }



    void FixedUpdate()
    {
        CharacterCheckGround();
        CharacterHurtCheck();
        CharacterIdleCheck();
        CharacterAnimation();
    }

    public void CharacterInit()
    {
        if (Globe.characterIndex == 0)
        {
            myAnimator.runtimeAnimatorController =
                Resources.Load("Animation/CharacterAstro") as
                RuntimeAnimatorController;
        }

        if (Globe.characterIndex == 1)
        {
            // 切换animator
            myAnimator.runtimeAnimatorController =
                Resources.Load("Animation/CharacterNinja") as
                RuntimeAnimatorController;
        }
    }

    private void ParameterInit()
    {
        speed = 400.0f;
        walkSpeed = 400.0f;
        runSpeed = 650.0f;
        jumpForce = 980.0f;

        dashTime = (float)0.35;
        dashLast = -100;
        dashSpeed = 1400;
        dashCoolDown = 2;

        faceLastPosition = 1;
    }

    private void CharacterCheckGround()
    {
        isGround = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, Ground);
    }



    private void CharacterRevivePressed()
    {
        // if (Input.GetKeyDown(KeyCode.P))
        // {

        //     PlayerInfo.getInstance().Reload();
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //     Time.timeScale = 1f;
        // }
    }

    private void CharacterDiePressed()
    {
        // if (Input.GetKeyDown(KeyCode.L))
        // {
        //     // Destroy PlayerInfo.getInstance() 
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //     Time.timeScale = 1f;
        // }
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
                myRigidbody2D.velocity =
                    new Vector2(myRigidbody2D.velocity.x,
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
            music.clip = jump;
            music.Play();
        }
    }

    private void CharacterDash()
    {
        if (isDashing)
        {
            if (dashTimeLeft > 0)
            {
                myRigidbody2D.velocity =
                    new Vector2(moveHorizontal *
                        dashSpeed *
                        Time.fixedDeltaTime,
                        0);
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
                music.clip = run;
                music.Play();
                isDashing = true;
                dashTimeLeft = dashTime;
                dashLast = Time.time;
                skillImage.fillAmount = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            skillImage2.fillAmount = 1;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            skillImage3.fillAmount = 1;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            skillImage4.fillAmount = 1;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            skillImage5.fillAmount = 1;
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
                hammer.SetActive(true);
                hand.SetActive(true);
                myAnimator.SetBool("Hurt", false);
            }
        }
    }

    private void CharacterDashCoolDown()
    {
        skillImage.fillAmount -= 1.0f / dashCoolDown * Time.deltaTime;
        skillImage2.fillAmount -= 1.0f / MagicCoolDown1 * Time.deltaTime;
        skillImage3.fillAmount -= 1.0f / MagicCoolDown2 * Time.deltaTime;
        skillImage4.fillAmount -= 1.0f / MagicCoolDown3 * Time.deltaTime;
        skillImage5.fillAmount -= 1.0f / MagicCoolDown4 * Time.deltaTime;
    }

    //武器相关
    private float LastShoot = 0;


    // public AudioClip launchClip; // 发射音效
    public void HandleInput()
    {
        if (
            Input.GetKeyDown(KeyCode.J) &&
            Time.time >= LastShoot + BulletCoolDown
        )
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (p.minusInc())
            {
                isShield = true;
                Shield.SetActive(true);
                shieldTime = Time.time;
            }
        }
    }

    public void Shoot()
    {
        if (bulletPrefab != null)
        {
            GameObject bullet =
                Instantiate(bulletPrefab,
                myRigidbody2D.position + new Vector2(0, 0.9f),
                Quaternion.identity);

            BulletController bc = bullet.GetComponent<BulletController>();
            if (bc != null)
            {
                bc.Move(new Vector2(faceLastPosition, 0), bc.BulletSpeed);

            }

            LastShoot = Time.time;
            //AudioManager.instance.AudioPlay(launchClip); //播放攻击音效
        }
    }


    // 技能相关
    private float LastMagic1 = 0;
    private float LastMagic2 = 0;
    private float LastMagic3 = 0;
    public GameObject MagicPrefeb1;
    public GameObject MagicPrefeb2;
    public GameObject MagicPrefeb3;

    public void ReleaseMagic()
    {
        //InGameUI p = new InGameUI();
        //magic_inc p = new magic_inc(); 
        if (Input.GetKeyDown(KeyCode.U) && Time.time >= LastMagic1 + MagicCoolDown1)
        {
            if (p.minusM1())
            {
                Debug.Log("pass here");
                Magic1();
            }
        }
        if (Input.GetKeyDown(KeyCode.I) && Time.time >= LastMagic2 + MagicCoolDown2)
        {
            if (p.minusM2())
            {
                Magic2();
            }
        }
        if (Input.GetKeyDown(KeyCode.O) && Time.time >= LastMagic3 + MagicCoolDown3)
        {
            if (p.minusM3())
            {
                Magic3();
            }
        }

    }

    public void Magic1()
    {
        if (MagicPrefeb1 != null)
        {
            music.clip = m1;
            music.Play();

            GameObject magic1 = Instantiate(MagicPrefeb1, myRigidbody2D.position + new Vector2(0, 0.9f), Quaternion.identity);

            MagicController mc = magic1.GetComponent<MagicController>();
            if (mc != null)
            {
                mc.Move(new Vector2(faceLastPosition, 0), mc.MagicSpeed);
                MyInpulse.GenerateImpulse();
                Debug.Log("魔法1发射了");
            }

            LastMagic1 = Time.time;
        }
    }

    public void Magic2()
    {
        if (MagicPrefeb2 != null)
        {
            music.clip = m2;
            music.Play();

            GameObject magic2 = Instantiate(MagicPrefeb2, myRigidbody2D.position + new Vector2(0, 0.9f), Quaternion.identity);

            MagicController mc = magic2.GetComponent<MagicController>();
            if (mc != null)
            {
                mc.Move(new Vector2(faceLastPosition, 0), mc.MagicSpeed);
                MyInpulse.GenerateImpulse();
                Debug.Log("魔法2发射了");
            }

            LastMagic2 = Time.time;
        }
    }

    public void Magic3()
    {
        if (MagicPrefeb3 != null)
        {
            music.clip = m3;
            music.Play();

            GameObject magic3 = Instantiate(MagicPrefeb3, myRigidbody2D.position + new Vector2(0, 0.9f), Quaternion.identity);

            MagicController mc = magic3.GetComponent<MagicController>();
            if (mc != null)
            {
                mc.Move(new Vector2(faceLastPosition, 0), mc.MagicSpeed);
                MyInpulse.GenerateImpulse();
                Debug.Log("魔法3发射了");
            }

            LastMagic3 = Time.time;
        }
    }



    // 与monster 交互相关
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!isShield)
        {
            // boss 
            if (collision.gameObject.tag == "wizard")
            {
                hurtAnimation();
                wizard tmp;
                tmp = collision.gameObject.GetComponent<wizard>();
                health.TakeDamage(tmp.AttackPlayer());
            }

            if (collision.gameObject.tag == "Warlock")
            {
                hurtAnimation();
                warlock tmp;
                tmp = collision.gameObject.GetComponent<warlock>();
                health.TakeDamage(tmp.AttackPlayer());
            }

            if (collision.gameObject.tag == "StormMage")
            {
                hurtAnimation();
                storm_mage tmp;
                tmp = collision.gameObject.GetComponent<storm_mage>();
                health.TakeDamage(tmp.AttackPlayer());
            }

            // AI
            if (collision.gameObject.tag == "shell_monster")
            {
                hurtAnimation();
                health.TakeDamage(1);
            }

            if (collision.gameObject.tag == "square")
            {
                hurtAnimation();

                square tmp;
                tmp = collision.gameObject.GetComponent<square>();
                health.TakeDamage(tmp.AttackPlayer());
            }

            if (collision.gameObject.tag == "mosquito")
            {
                hurtAnimation();
                health.TakeDamage(1);
            }

            if (collision.gameObject.tag == "slime")
            {
                hurtAnimation();
                health.TakeDamage(1);
            }

            if (collision.gameObject.tag == "beetle")
            {
                hurtAnimation();
                health.TakeDamage(1);
            }

            //boss的技能
            if (collision.gameObject.tag == "wizard_bullet")
            {
                hurtAnimation();
                health.TakeDamage(6);
            }

            if (collision.gameObject.tag == "lightning")
            {
                hurtAnimation();
                health.TakeDamage(6);
            }

            if (collision.gameObject.tag == "zombie")
            {
                hurtAnimation();
                health.TakeDamage(6);
            }
        }
    }

    public void hurtAnimation()
    {
        isHurt = true;
        hammer.SetActive(false);
        hand.SetActive(false);
        //health.TakeDamage(2);
        myAnimator.SetBool("Hurt", true);
        music.clip = hurtAudio;//把音源music的音效设置为jump
        music.Play();//播放音效
        MyInpulse.GenerateImpulse();
        hurtTimeLeft = Time.time;
    }

    public void CheckDialog()
    {
        if (!showD1)
        {
            if (this.transform.position.x >= p1.position.x && this.transform.position.y > p1.position.y - 3 && this.transform.position.y < p1.position.y + 4)
            {
                dialog1.SetActive(true);
                Invoke("test", 2.1f);
                showD1 = true;
            }
        }

        if (!showD2)
        {
            if (this.transform.position.x >= p2.position.x)
            {
                dialog2.SetActive(true);
                Invoke("test_dia", 2.1f);
                showD2 = true;
            }
        }
    }

    void test()
    {
        Destroy(dialog1);
    }

    void test_dia()
    {
        Destroy(dialog2);
    }
}

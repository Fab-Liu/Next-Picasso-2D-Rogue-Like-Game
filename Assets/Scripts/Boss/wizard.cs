using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizard : MonoBehaviour
{
    public int Speed = 5;
    public GameObject BulletPerfabs;
    public Transform BulletPoint;
    public Transform leftpoint, rightpoint;
    public bool isSkill;

    [Header("Components")]
    [SerializeField] protected Animator animator;
    public Collider2D myCollider;

    private float timer = 0;
    private float tmp_timer = 0;
    private Rigidbody2D rb;
    private bool isDead = false;
    private bool isShoot = false;
    public bool isAngry = false;
    private bool isHurt = false;
    public bool isAttack = false;
    public bool isMove = false;

    private float Xleft, Xright;
    private float IsFaceRight = 0;

    public HealthBar healthBar;
    public GameObject bar;

    public GameObject blood;
    private float keyTimer = 0;

    public AudioSource music;
    public AudioClip hurt;
    public AudioClip skill;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
        healthBar = GetComponent<HealthBar>();
        Xleft = leftpoint.position.x;
        Xright = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
        animator.SetBool("IsDie", false);
        animator.SetBool("IsHurt", false);
        animator.SetBool("IsAttack", false);
        animator.SetBool("IsSkill", false);
        animator.SetBool("IsIdle", true);
        animator.SetBool("IsMove", false);

        music = gameObject.AddComponent<AudioSource>();
        music.playOnAwake = false;
        hurt = Resources.Load<AudioClip>("Sound/monster/hurt_monster_3");
        skill = Resources.Load<AudioClip>("Sound/monster/bullet_magic");
    }

    // Update is called once per frame
    void Update()
    {
        if(healthBar.currentHealth <= 0 && !isDead){
            isDead = true;
            timer = Time.time;
            Debug.Log("it`s working");
            animator.SetBool("IsDie", true);
        }

        if(isAngry){

            if(isSkill && Time.time - timer > 0.9){
                animator.SetBool("IsSkill", false);
                isSkill = false;
                isShoot = false;
                timer = Time.time;
            }

            if(isSkill && !isShoot && Time.time - timer > 0.4){
                shoot();
                isShoot = true;
                tmp_timer = Time.time;
            }

        }else{
            if(Time.time - timer > 1 && isAttack){
                animator.SetBool("IsAttack", false);
                isAttack = false;
                timer = Time.time;
            }

        }

        if(isMove && Time.time - timer > 4){
            isMove = false;
            animator.SetBool("IsMove", false);
            if(isAngry){
                isSkill = true;
                animator.SetBool("IsSkill", true);
            }
            else{
                animator.SetBool("IsAttack", true);
                isAttack = true;
            }
            timer = Time.time;
        }

        if(!isMove && !isSkill && !isAttack && Time.time - timer > 3){
            isMove = true;
            animator.SetBool("IsMove", true);
            isShoot = false;
            timer = Time.time;
        }

        if(Input.GetKeyDown(KeyCode.J)){
            keyTimer = Time.time;
            myCollider.isTrigger = true;
        }

        if(Time.time - keyTimer > 0.7){
            keyTimer = 0;
            myCollider.isTrigger = false;
        }

        if(isHurt && isDead)  rb.velocity = new Vector2(0, rb.velocity.y);

        if(isHurt && Time.time - timer > 0.2){
            healthBar.damage(1);
            animator.SetBool("IsHurt", false);
            isHurt = false;
        }

        if(isDead && Time.time - timer > 0.9){
            Destroy(bar);
            Destroy(this.gameObject);
            Application.LoadLevel("L1_work");
        }

        if(isMove)
            Movement();
        else
            rb.velocity = new Vector2(0, rb.velocity.y);
    }

    void Movement(){
        if(IsFaceRight == 1)
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
            if(transform.position.x > Xright){
                transform.localScale = new Vector3(-2,2,1);
                BulletPoint.localScale = new Vector3(-1,1,1);
                IsFaceRight = 0;
            }
        }else if (IsFaceRight != 1){
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
            if(transform.position.x < Xleft){
                transform.localScale = new Vector3(2,2,1);
                BulletPoint.localScale = new Vector3(1,1,1);
                IsFaceRight = 1;
            }
        }

        healthBar.turn(transform.position.x,transform.position.y + 2);
    }

    void shoot(){
        float x,y;
        wizard_skill bc = GetComponent<wizard_skill>();
        music.clip = skill;
        music.Play();
        GameObject tmp = Instantiate(BulletPerfabs, BulletPoint.position, transform.rotation);
        if(IsFaceRight == 1)
            tmp.transform.localScale = new Vector3(1,1,1);
        else
            tmp.transform.localScale = new Vector3(-1,1,1);
        // bc.Move(x, 30f);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(!isSkill && !isAttack && keyTimer != 0){
            getHurt();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!isSkill && !isAttack && keyTimer != 0){
            if(!isHurt) healthBar.damage(1);
            getHurt();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Black")
        {
            getHurt();
            healthBar.damage(3);
        }

        if (collision.gameObject.tag == "Rock")
        {
            getHurt();
            healthBar.damage(2);
        }

        if (collision.gameObject.tag == "Tornado")
        {
            getHurt();
            healthBar.damage(4);
        }
    }

    public void getHurt(){
        isHurt = true;
        isAngry = true;
        animator.SetBool("IsHurt", true);
        music.clip = hurt;
        music.Play();
        Instantiate(blood, this.transform.position, this.transform.rotation);
        timer = Time.time;
    }

    public int AttackPlayer(){
        if(isAngry)
            if(isAttack)
                return 6;
            else
                return 3;
        else
            if(isAttack)
                return 3;
            else
                return 2;
    }
    
}

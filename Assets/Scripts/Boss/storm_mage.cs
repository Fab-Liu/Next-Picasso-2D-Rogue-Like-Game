using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storm_mage : MonoBehaviour
{
    public int Speed = 5;
    public Transform leftpoint, rightpoint;
    public GameObject l1, l2, l3, l4, s1, s2, s3, s4;
    public Transform lp1, lp2, lp3, lp4, sp1, sp2, sp3, sp4;

    [Header("Components")]
    [SerializeField] protected Animator animator;
    public Collider2D myCollider;

    private float timer = 0;
    private float tmp_timer = 0;
    private Rigidbody2D rb;

    private bool isLight = false;
    public bool isSkill = false;
    private bool isAngry = true;
    private bool isDie = false;
    private bool isHurt = false;
    private bool isMove = false;

    private float Xleft, Xright;
    private float IsFaceRight = 0;

    public HealthBar healthBar;
    public GameObject bar;

    public GameObject blood;
    private float keyTimer = 0;


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
        animator.SetBool("IsDead", false);
        animator.SetBool("IsHurt", false);
        animator.SetBool("IsMove", false);
        animator.SetBool("IsSkill", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isAngry){
            if(isSkill){
                if(isSkill && Time.time - timer > 1.5){
                    isSkill = false;
                    animator.SetBool("IsSkill", false);
                    isMove = true;
                    animator.SetBool("IsMove", true);
                    timer = Time.time;
                    Invoke("test",0.2f);
                    //bar.SetActive(true);
                }

                if(!isLight && Time.time - timer > 0.5){
                    light();
                    isLight = true;
                    tmp_timer = Time.time;
                }

                if(isLight && Time.time - tmp_timer > 1){
                    isLight = false;
                }
            }
        }else{
            if(isSkill){
                if(isSkill && Time.time - timer > 1.5){
                    isSkill = false;
                    animator.SetBool("IsSkill", false);
                    isMove = true;
                    animator.SetBool("IsMove", true);
                    timer = Time.time;
                    Invoke("test",0.2f);
                    //bar.SetActive(true);
                }
            }
        }

        if(isMove && Time.time - timer > 4){
            isMove = false;
            animator.SetBool("IsMove", false);
            timer = Time.time;
        }

        if(!isMove && !isSkill && Time.time - timer > 1){
            isSkill = true;
            animator.SetBool("IsSkill", true);
            bar.SetActive(false);
            timer = Time.time;
        } 

        if(isMove)
            Movement();
        else
            rb.velocity = new Vector2(0, rb.velocity.y);


        if(Input.GetKeyDown(KeyCode.J)){
            keyTimer = Time.time;
            myCollider.isTrigger = true;
        }

        if(Time.time - keyTimer > 0.7){
            keyTimer = 0;
            myCollider.isTrigger = false;
        }

        if(isHurt)  rb.velocity = new Vector2(0, rb.velocity.y);

        if(isHurt && Time.time - timer > 0.2){
            animator.SetBool("IsHurt", false);
            isHurt = false;
        }

        if(healthBar.currentHealth <= 0 && !isDie){
            isDie = true;
            timer = Time.time;
            animator.SetBool("IsDead", true);
        }

        if(isDie && Time.time - timer > 0.4){
            Destroy(bar);
            Destroy(this.gameObject);
        }

        
        healthBar.turn(transform.position.x,transform.position.y);

    }

    void Movement(){
        if(IsFaceRight == 1)
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
            if(transform.position.x > Xright){
                transform.localScale = new Vector3(-2,2,1);
                IsFaceRight = 0;
            }
        }else if (IsFaceRight != 1){
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
            if(transform.position.x < Xleft){
                transform.localScale = new Vector3(2,2,1);
                IsFaceRight = 1;
            }
        }
    }

    void test() {
        bar.SetActive(true);
    }

    void light(){
        Instantiate(l1, lp1.position, lp1.rotation);
        Instantiate(l2, lp2.position, lp2.rotation);
        Instantiate(l3, lp3.position, lp3.rotation);
        Instantiate(l4, lp4.position, lp4.rotation);
        Instantiate(s1, sp1.position, sp1.rotation);
        Instantiate(s2, sp2.position, sp2.rotation);
        Instantiate(s3, sp3.position, sp3.rotation);
        Instantiate(s4, sp4.position, sp4.rotation);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(!isSkill && keyTimer != 0){
            //Debug.Log("trigger is working(shell)");
            isHurt = true;
            animator.SetBool("IsHurt", true);
            Instantiate(blood, this.transform.position, this.transform.rotation);
            timer = Time.time;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!isSkill && keyTimer != 0){
            //Debug.Log("trigger is working(shell)");
            if(!isHurt) healthBar.damage(1);
            isHurt = true;
            animator.SetBool("IsHurt", true);
            Instantiate(blood, this.transform.position, this.transform.rotation);
            timer = Time.time;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Black")
        {
            isHurt = true;
            animator.SetBool("IsHurt", true);
            healthBar.damage(3);
            Instantiate(blood, this.transform.position, this.transform.rotation);
            timer = Time.time;
        }

        if (collision.gameObject.tag == "Rock")
        {
            isHurt = true;
            animator.SetBool("IsHurt", true);
            healthBar.damage(2);
            Instantiate(blood, this.transform.position, this.transform.rotation);
            timer = Time.time;
        }

        if (collision.gameObject.tag == "Tornado")
        {
            isHurt = true;
            animator.SetBool("IsHurt", true);
            healthBar.damage(4);
            Instantiate(blood, this.transform.position, this.transform.rotation);
            timer = Time.time;
        }
    }

    public int AttackPlayer(){
        if(isAngry)
            if(isSkill)
                return 6;
            else
                return 3;
        else
            if(isSkill)
                return 3;
            else
                return 2;
    }


}

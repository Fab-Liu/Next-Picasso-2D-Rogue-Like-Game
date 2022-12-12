using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warlock : MonoBehaviour
{
    public int Speed = 5;
    public Transform leftpoint, rightpoint;
    public GameObject g1, g2, g3, g4, g5, g6, g7, g8;
    public Transform p1, p2, p3, p4, p5, p6, p7, p8;
    
    [Header("Components")]
    [SerializeField] protected Animator animator;
    public Collider2D myCollider;

    private float timer = 0;
    private float tmp_timer = 0;
    private Rigidbody2D rb;

    private bool isCall = false;
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
        animator.SetBool("IsDie", false);
        animator.SetBool("IsHurt", false);
        animator.SetBool("IsMove", false);
        animator.SetBool("IsSkill", false);
        animator.SetBool("IsCallZombie", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isAngry){
            if(isSkill){
                if(isSkill && Time.time - timer > 0.3){
                    isSkill = false;
                    animator.SetBool("IsCallZombie", false);
                    timer = Time.time;
                }

                if(!isCall && Time.time - timer > 0.2){
                    zombie();
                    isCall = true;
                    tmp_timer = Time.time;
                }
            }
        }else{
            if(isSkill){
                if(isSkill && Time.time - timer > 1.5){
                    isSkill = false;
                    animator.SetBool("IsSkill", false);
                    timer = Time.time;
                }
            }
        }

        if(isMove && Time.time - timer > 4){
            isMove = false;
            animator.SetBool("IsMove", false);
            isSkill = true;
            if(isAngry)
                animator.SetBool("IsCallZombie", true);
            else
                animator.SetBool("IsSkill", true);
            timer = Time.time;
        }

        if(!isMove && !isSkill && Time.time - timer > 4){
            isMove = true;
            animator.SetBool("IsMove", true);
            isCall = false;
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

        if(isHurt && Time.time - timer > 0.2 && !isDie){
            animator.SetBool("IsHurt", false);
            isHurt = false;
        }

        if(healthBar.currentHealth <= 0 && !isDie){
            isDie = true;
            timer = Time.time;
            animator.SetBool("IsDie", true);
        }

        if(isDie && Time.time - timer > 0.8){
            Destroy(bar);
            Destroy(this.gameObject);
        }

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

        healthBar.turn(transform.position.x,transform.position.y + 2);
    }

    void zombie(){
        Instantiate(g1, p1.position, p1.rotation);
        Instantiate(g2, p2.position, p2.rotation);
        Instantiate(g3, p3.position, p3.rotation);
        Instantiate(g4, p4.position, p4.rotation);
        Instantiate(g5, p5.position, p5.rotation);
        Instantiate(g6, p6.position, p6.rotation);
        Instantiate(g7, p7.position, p7.rotation);
        Instantiate(g8, p8.position, p8.rotation);
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
            if(!isHurt) healthBar.damage(1);
            isHurt = true;
            animator.SetBool("IsHurt", true);
            Instantiate(blood, new Vector3(this.transform.position.x - 0.5f, this.transform.position.y + 2, this.transform.position.z),this.transform.rotation);
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

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

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
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
            timer = Time.time;
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

    
}

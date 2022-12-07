using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class square : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] protected Animator animator;
    public Collider2D myCollider;
    public Transform leftpoint, rightpoint;
    public float Speed = 3;


    private float timer = 0;
    private float Xleft, Xright;
    private float IsFaceRight = 0;
    private Rigidbody2D rb;


    private bool isFly = false;
    private bool isIdle = true;
    private bool isAttack = false;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
        animator.SetBool("IsFly", false);
        animator.SetBool("IsDead", false);
        animator.SetBool("IsAttack", false);
        animator.SetBool("IsIdle", true);
        Xleft = leftpoint.position.x;
        Xright = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    
        //idle -> fly
        if(Time.time - timer > 2 && isIdle){
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsFly", true);
            isIdle = false;
            isFly = true;
            timer = Time.time;
        }

        //fly -> attack
        if(Time.time - timer > 2.5 && isFly){
            animator.SetBool("IsFly", false);
            animator.SetBool("IsAttack", true);
            isFly = false;
            isAttack = true;
            timer = Time.time;
        }

        //attack -> idle
        if(Time.time - timer > 0.75 && isAttack){
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsIdle", true);
            isAttack = false;
            isIdle = true;
            timer = Time.time;
        }

        if(isFly){
            movement();
        }else{
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    void movement(){
        if(IsFaceRight == 1)
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
            if(transform.position.x > Xright){
                transform.localScale = new Vector3(3,3,1);
                IsFaceRight = 0;
            }
        }else if (IsFaceRight != 1){
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
            if(transform.position.x < Xleft){
                transform.localScale = new Vector3(-3,3,1);
                IsFaceRight = 1;
            }
        }
    }
}

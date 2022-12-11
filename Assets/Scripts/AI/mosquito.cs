using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mosquito : MonoBehaviour
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

    private bool isDead = false;

    private float keyTimer = 0;

    public GameObject blood;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
        animator.SetBool("IsDie", false);
        Xleft = leftpoint.position.x;
        Xright = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead){
            rb.velocity = new Vector2(0, rb.velocity.y);
            if(Time.time - timer > 0.45)
                Destroy(this.gameObject);
        }else{
            movement();
        }

        if(Input.GetKeyDown(KeyCode.J)){
            keyTimer = Time.time;
        }

        if(Time.time - keyTimer > 0.7){
            keyTimer = 0;
        }
    }

    void movement(){
        if(IsFaceRight == 1)
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
            if(transform.position.x > Xright){
                transform.localScale = new Vector3(2,2,1);
                IsFaceRight = 0;
            }
        }else if (IsFaceRight != 1){
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
            if(transform.position.x < Xleft){
                transform.localScale = new Vector3(-2,2,1);
                IsFaceRight = 1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(keyTimer != 0){
            //Debug.Log("trigger is working(shell)");
            isDead = true;
            animator.SetBool("IsDie", true);
            Instantiate(blood, this.transform.position, this.transform.rotation);
            timer = Time.time;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(keyTimer != 0){
            //Debug.Log("trigger is working(shell)");
            isDead = true;
            animator.SetBool("IsDie", true);
            Instantiate(blood, this.transform.position, this.transform.rotation);
            timer = Time.time;
        }
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "Bullet")
    //     {
    //         animator.SetBool("IsDeath", true);
    //         dieTime = Time.time;
    //     }

    // }
}

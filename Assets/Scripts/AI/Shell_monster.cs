using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell_monster : MonoBehaviour
{
    private float dieTime = 0;
    private float lookTime = 0;
    private float shellTime = 0;
    private Rigidbody2D rb;

    private bool isDie = false;
    private bool isLook = false;

    public float Shell_time = 5;
    private float timer = 0;

    private float keyTimer = 0;

    public GameObject blood;



    [Header("Components")]
    [SerializeField] protected Animator animator;
    public Collider2D myCollider;


    // Start is called before the first frame update
    void Start()
    {
        shellTime = Time.time;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
        animator.SetBool("IsDead", false);
        animator.SetBool("IsLook", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isDie && Time.time - timer > 0.2){
            Destroy(this.gameObject);
        }
        
        if(Time.time - shellTime > Shell_time && !isLook)
        {
            animator.SetBool("IsLook", true);
            isLook = true;
            lookTime = Time.time;
        }

        if(isLook && Time.time - lookTime > 2.15){
            animator.SetBool("IsLook", false);
            isLook = false;
            shellTime = Time.time;
        }

        

        if(Input.GetKeyDown(KeyCode.J)){
            keyTimer = Time.time;
        }

        if(Time.time - keyTimer > 1){
            keyTimer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(isLook && keyTimer != 0){
            //Debug.Log("trigger is working(shell)");
            isDie = true;
            animator.SetBool("IsDead", true);
            timer = Time.time;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(isLook && keyTimer != 0){
            //Debug.Log("trigger is working(shell)");
            isDie = true;
            animator.SetBool("IsDead", true);
            Instantiate(blood, this.transform.position, this.transform.rotation);
            timer = Time.time;
        }
    }


    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     Debug.Log("collision is working");
    //     if (collision.gameObject.tag == "Bullet")
    //     {
    //         animator.SetBool("IsDeath", true);
    //         dieTime = Time.time;
    //     }

    // }
}

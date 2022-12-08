using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizard : MonoBehaviour
{
    public GameObject BulletPerfabs;
    public Transform BulletPoint;
    public bool isSkill;

    [Header("Components")]
    [SerializeField] protected Animator animator;
    public Collider2D myCollider;

    private float timer = 0;
    private Rigidbody2D rb;
    private bool isDead = false;
    private bool isShoot = false;
    public bool isAngry = false;
    private bool isHurt = false;
    private bool isAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
        animator.SetBool("IsDie", false);
        animator.SetBool("IsHurt", false);
        animator.SetBool("IsAttack", false);
        animator.SetBool("IsSkill", false);
        animator.SetBool("IsIdle", true);
    }

    // Update is called once per frame
    void Update()
    {
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
            }

            if(!isSkill && Time.time - timer > 2){
                timer = Time.time;
                animator.SetBool("IsSkill", true);
                isSkill = true;
                isShoot = false;
            }
                


        }else{
            if(Time.time - timer > 3 && !isAttack){
                animator.SetBool("IsAttack", true);
                isAttack = true;
                timer = Time.time;
            }

            if(Time.time - timer > 0.9 && isAttack){
                animator.SetBool("IsAttack", false);
                isAttack = false;
                timer = Time.time;
            }
        }

    }

    void shoot(){
        Instantiate(BulletPerfabs, BulletPoint.position, BulletPoint.rotation);
    }
}

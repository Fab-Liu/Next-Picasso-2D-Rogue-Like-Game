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

    public Collider2D myCollider;
    public float Shell_time = 5;

    [Header("Components")]
    [SerializeField] protected Animator animator;


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
    }
}

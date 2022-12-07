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

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
        animator.SetBool("IsDie", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isSkill && !isShoot){
            shoot();
            isShoot = true;
        }

        if(!isSkill)
            isShoot = false;

    }

    void shoot(){
        Instantiate(BulletPerfabs, BulletPoint.position, BulletPoint.rotation);
    }
}

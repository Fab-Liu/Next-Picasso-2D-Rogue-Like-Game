using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storm_mage : MonoBehaviour
{
    public GameObject l1, l2, l3, l4, s1, s2, s3, s4;
    public Transform lp1, lp2, lp3, lp4, sp1, sp2, sp3, sp4;

    public bool isSkill;

    [Header("Components")]
    [SerializeField] protected Animator animator;
    public Collider2D myCollider;

    private float timer = 0;
    private Rigidbody2D rb;

    private bool isLight = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isLight){
            light();
            isLight = true;
            timer = Time.time;
        }

        if(isLight && Time.time - timer > 1.5){
            isLight = false;
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

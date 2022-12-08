using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    private Animator anim;
    public float tornadoForce = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D myCollider2d)
    {
        if(myCollider2d.gameObject.CompareTag("Player"))
        {
            //anim.SetTrigger("Jump");
            myCollider2d.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2, tornadoForce), ForceMode2D.Impulse);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    private Animator anim;
    public float vertForce = 25f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D myCollider2d)
    {
        if(myCollider2d.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("springUp");
            myCollider2d.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2, vertForce), ForceMode2D.Impulse);
        }
    }
}

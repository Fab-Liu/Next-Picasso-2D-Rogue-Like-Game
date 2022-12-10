using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterwave : MonoBehaviour
{
    public float waterForce = 10.0f;

    private void OnCollisionEnter2D(Collision2D myCollider2d)
    {
        if(myCollider2d.gameObject.CompareTag("Player"))
        {
            myCollider2d.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2, waterForce), ForceMode2D.Impulse);
        }
    }
}
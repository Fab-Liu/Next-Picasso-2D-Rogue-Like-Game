using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rbody;

    [Header("Magic Speed")]
    public float MagicCoolDown = 0.3f;

    public float MagicSpeed = 1200.0f;

    // Start is called before the first frame update
    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    //  魔法的移动
    public void Move(Vector2 moveDirection, float moveForce)
    {
        rbody.AddForce(moveDirection * moveForce);
    }

    // 碰撞检测
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
    }
}

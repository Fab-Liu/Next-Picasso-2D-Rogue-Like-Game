using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Rigidbody2D rbody;

    [Header("Bullet Speed")]
    public float BulletCoolDown = 0.5f;
    public float BulletSpeed;
    
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
    //子弹的移动
    public void Move(Vector2 moveDirection, float moveForce){
        rbody.AddForce(moveDirection * moveForce);
    }

    // 碰撞检测
    void OnCollisionEnter2D(Collision2D other){
        Destroy(this.gameObject);
    }
}

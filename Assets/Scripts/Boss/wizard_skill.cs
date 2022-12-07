using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizard_skill : MonoBehaviour
{
    public Rigidbody2D rbody;

    [Header("Bullet Speed")]
    public float BulletCoolDown = 0.5f;
    public float BulletSpeed = 20;
    public Transform BulletPoint;

    void Start(){
        rbody.velocity = -1 * transform.right * BulletSpeed * 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(BulletPoint.position.x - rbody.position.x > 4)
            Destroy(this.gameObject);
    }

    // 碰撞检测
    void OnCollisionEnter2D(Collision2D other){
        Destroy(this.gameObject);
    }
}
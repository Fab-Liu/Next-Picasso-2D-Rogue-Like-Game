using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storm_skill : MonoBehaviour
{
    public Rigidbody2D rbody;
    public Transform Point;

    private float timer;

    void Start(){
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - timer > 1)
            Destroy(this.gameObject);
    }

    // 碰撞检测
    void OnCollisionEnter2D(Collision2D other){
        Destroy(this.gameObject);
    }
}

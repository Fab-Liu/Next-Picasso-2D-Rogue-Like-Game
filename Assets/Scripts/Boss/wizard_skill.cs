using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizard_skill : MonoBehaviour
{
    public Rigidbody2D rbody;
    public Transform BulletPoint;

    private float timer = 0;


    void Start(){
        Debug.Log("this is created");
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - timer > 0.4)
            Destroy(this.gameObject);

        if(this.gameObject.transform.localScale.x > 0)
            transform.Translate(Vector2.right*60f*Time.deltaTime);
        else
            transform.Translate(Vector2.left*60f*Time.deltaTime);
    }


    // 碰撞检测
    void OnCollisionEnter2D(Collision2D other){
        Destroy(this.gameObject);
    }

}
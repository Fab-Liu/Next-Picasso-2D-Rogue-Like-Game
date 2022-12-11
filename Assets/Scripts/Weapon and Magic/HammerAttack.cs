using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 如果用户按下J键，就执行攻击
        if (Input.GetKeyDown(KeyCode.J))
        {
            // 1.获取动画组件
            Animator anim = GetComponent<Animator>();
            // 2.播放攻击动画
            anim.SetBool("Attack", true);

        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            // 1.获取动画组件
            Animator anim = GetComponent<Animator>();
            // 2.播放攻击动画
            anim.SetBool("Attack", false);
        }

    }
}

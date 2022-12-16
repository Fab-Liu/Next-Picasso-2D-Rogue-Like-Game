using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAttack : MonoBehaviour
{
    // public Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        // myAnimator = GetComponent<Animator>();
        // if (Globe.characterIndex == 1)
        // {
        //     // myAnimator.runtimeAnimatorController = Resources.Load("Animator/hammer_side_cover_ninja") as RuntimeAnimatorController;
        // }

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

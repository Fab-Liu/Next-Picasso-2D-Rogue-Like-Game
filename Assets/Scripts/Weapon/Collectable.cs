using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// 武器被玩家碰撞时检测的相关类
public class Collectable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        CharacterController characterController = other.GetComponent<CharacterController>();
        if(characterController != null){
            Debug.Log("玩家拾取了武器！");
            Destroy(this.gameObject);
        }
    }
}

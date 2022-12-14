using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inc : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D myCollider2d)
    {        
        if(myCollider2d.gameObject.CompareTag("Player") && myCollider2d.GetType().ToString() == "UnityEngine.CircleCollider2D")
        {
            magic_inc.inc++;
            Destroy(gameObject);  //Destroy food object
            
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private int healAmount;

    void OnTriggerEnter2D(Collider2D myCollider2d)
    {        
        if(myCollider2d.gameObject.CompareTag("Player") && myCollider2d.GetType().ToString() == "UnityEngine.CircleCollider2D")
        {
            if(PlayerHealth.healthCurrent < PlayerHealth.healthMax)
            {
                PlayerHealth.healthCurrent += healAmount;
                Destroy(gameObject);  //Destroy food object
            }
        }
    }
}
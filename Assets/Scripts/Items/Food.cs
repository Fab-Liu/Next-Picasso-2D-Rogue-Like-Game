using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    //private Health playerHealth;
    //private int maxHealth = 10;

    // Start is called before the first frame update
    void Start()
    {
        //playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    void OnTriggerEnter2D(Collider2D myCollider2d)
    {        
        if(myCollider2d.gameObject.CompareTag("Player") && myCollider2d.GetType().ToString() == "UnityEngine.CircleCollider2D")
        {
            //if(playerHealth.CurrentHealth < maxHealth)
            //{
                //playerHealth.CurrentHealth += 1;
                //playerHealth.UpdateCharacterHealth();
                Destroy(gameObject);
            //}
        }
    }
}
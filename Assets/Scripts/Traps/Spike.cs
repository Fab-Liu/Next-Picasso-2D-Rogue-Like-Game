using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public int spikeDamage;
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D myCollider2d)
    {
        
        if(myCollider2d.CompareTag("Player") && myCollider2d.GetType().ToString() == "UnityEngine.CircleCollider2D")
        {
            playerHealth.TakeDamage(spikeDamage);
        }
    }
}
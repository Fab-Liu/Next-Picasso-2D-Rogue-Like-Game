using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;  //Init health
    public static int healthCurrent;
    public static int healthMax;
    public float dieTime;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        healthMax = health;
        healthCurrent = health;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))  //For testing
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health < 0)
        {
            health = 0;
        }
        healthCurrent = health;

        if (health <= 0)
        {
            Invoke("KillPlayer", dieTime);
        }
    }

    void KillPlayer()
    {
        Destroy(gameObject);
    }
}
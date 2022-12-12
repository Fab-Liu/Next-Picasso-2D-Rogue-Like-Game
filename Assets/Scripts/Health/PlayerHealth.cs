using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Character character;
    public int health;  //Init health
    public static int healthCurrent;
    public static int healthMax;
    public float dieTime;
    private Animator anim;
    private PlayerHealthBar playerHealthBar;
    public GameObject bar;

    private blood b;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerHealthBar = bar.GetComponentInChildren<PlayerHealthBar>();
        healthMax = health;
        healthCurrent = health;
        b = GetComponent<blood>();
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
        if (healthCurrent <= 0)
        {
            return;
        }
        healthCurrent -= damage;

        b.FlashScreen();

        if (healthCurrent <= 0)
        {
            healthCurrent = 0;
            Invoke("KillPlayer", dieTime);
        }
        playerHealthBar.UpdateHealth(healthCurrent, healthMax);

    }

    void KillPlayer()
    {
        Destroy(gameObject);
    }
}
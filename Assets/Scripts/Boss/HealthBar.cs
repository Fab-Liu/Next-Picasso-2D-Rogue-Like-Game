using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] public float initialHealth = 20f;
    [SerializeField] public float maxHealth = 20f;
    public float currentHealth;

    [Header("Settings")]
    [SerializeField] public bool destroyObject;

    private Character character;
    private CharacterController controller;
    public Image healthBar;
    private SpriteRenderer spriteRenderer;
    public float fill;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
        controller = GetComponent<CharacterController>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        currentHealth = initialHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        fill = currentHealth / maxHealth;
        healthBar.fillAmount = fill;
    }

    public float healthLevel()
    {
        return currentHealth;
    }

    public void damage(int num)
    {
        currentHealth = currentHealth - num;
        fill = currentHealth / maxHealth;
        healthBar.fillAmount = fill;
        return;
    }

    public void turn(float x, float y)
    {
        healthBar.transform.position = new Vector3(x,y + 2,1);
    }

}
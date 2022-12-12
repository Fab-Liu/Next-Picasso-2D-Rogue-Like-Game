using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;

public class PlayerHealthBar : MonoBehaviour
{
    public Text healthText;
    private Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        InternalUpdate();
    }

    public void UpdateHealth(int currentHealth, int maxHealth)  //Update player health
    {
        PlayerHealth.healthCurrent = currentHealth;
        PlayerHealth.healthMax = maxHealth;
    }

    private void InternalUpdate()
    {
        healthBar.fillAmount = (float)PlayerHealth.healthCurrent / (float)PlayerHealth.healthMax;
        healthText.text = PlayerHealth.healthCurrent.ToString() + "/" + PlayerHealth.healthMax.ToString();
    }
}
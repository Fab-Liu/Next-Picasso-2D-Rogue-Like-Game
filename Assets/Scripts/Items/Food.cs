using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private int healAmount;

    private AudioSource music;
    public AudioClip pick;

    void Start()
    {
        music = GameObject.Find("LevelComponent").GetComponent<AudioSource>();
        music.playOnAwake = false;
    }

    void OnTriggerEnter2D(Collider2D myCollider2d)
    {
        if (myCollider2d.gameObject.CompareTag("Player") && myCollider2d.GetType().ToString() == "UnityEngine.CircleCollider2D")
        {
            if (PlayerHealth.healthCurrent < PlayerHealth.healthMax)
            {
                PlayerHealth.healthCurrent += healAmount;
                if (PlayerHealth.healthCurrent > PlayerHealth.healthMax)
                {
                    PlayerHealth.healthCurrent = PlayerHealth.healthMax;
                }
                music.clip = pick;
                music.Play();
                Destroy(gameObject);  //Destroy food object
            }
        }
    }
}
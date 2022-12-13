using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private int healAmount;

    public AudioSource music;
    public AudioClip pick;

    void Start(){
        music = gameObject.AddComponent<AudioSource>();
        music.playOnAwake = false;
        pick = Resources.Load<AudioClip>("Sound/PickUp");
    }

    void OnTriggerEnter2D(Collider2D myCollider2d)
    {        
        if(myCollider2d.gameObject.CompareTag("Player") && myCollider2d.GetType().ToString() == "UnityEngine.CircleCollider2D")
        {
            if(PlayerHealth.healthCurrent < PlayerHealth.healthMax)
            {
                PlayerHealth.healthCurrent += healAmount;
                if(PlayerHealth.healthCurrent > PlayerHealth.healthMax)
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
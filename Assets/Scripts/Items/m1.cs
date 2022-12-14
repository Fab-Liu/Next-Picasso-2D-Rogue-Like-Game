using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m1 : MonoBehaviour
{
    private AudioSource music;
    public AudioClip pick;
    void Start()
    {
        music = GameObject.Find("LevelComponent").GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D myCollider2d)
    {
        if (myCollider2d.gameObject.CompareTag("Player") && myCollider2d.GetType().ToString() == "UnityEngine.CircleCollider2D")
        {
            music.clip = pick;
            music.Play();
            magic_inc.m1++;
            Destroy(gameObject);  //Destroy food object

        }
    }
}

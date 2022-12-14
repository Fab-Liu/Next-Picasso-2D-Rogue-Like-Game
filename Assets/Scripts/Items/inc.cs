using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inc : MonoBehaviour
{
    private AudioSource music;
    public AudioClip pick;

    private bool playPick = false;

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
            magic_inc.inc++;
            Destroy(gameObject);  //Destroy food object

        }
    }
}
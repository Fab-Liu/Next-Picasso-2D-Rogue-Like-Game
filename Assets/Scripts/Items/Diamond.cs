using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public AudioSource music;
    public AudioClip pick;

    private bool playPick = false;

    void Start(){
        music = gameObject.AddComponent<AudioSource>();
        music.playOnAwake = false;
        pick = Resources.Load<AudioClip>("Sound/Money");
    }

    void Update()
	{
			if (playPick)
			{
                Debug.Log("pick up audio is working.");
                music.clip = pick;
                music.Play();
			}
	}

    void OnTriggerEnter2D(Collider2D myCollider2d)
    {        
        if(myCollider2d.gameObject.CompareTag("Player") && myCollider2d.GetType().ToString() == "UnityEngine.CircleCollider2D")
        {
            playPick = true;
            Destroy(gameObject);
            DiamondUI.currentDiamondNum += 1;
        }
    }
}
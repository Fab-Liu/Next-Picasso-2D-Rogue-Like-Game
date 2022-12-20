using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalMenu : MonoBehaviour
{
    public AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        // play victory music
        AudioClip victory = Resources.Load<AudioClip>("Sound/victory");
        audioSource.clip = victory;
        audioSource.Play();

    }

    private void Update() {
        
    }

    public void QuitGame()
    {
            Debug.Log("Quit");
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
    }

    public void back(){
        Application.LoadLevel("Menu");
    }
}

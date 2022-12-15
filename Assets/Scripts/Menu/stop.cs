using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class stop : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject obj, s, store;

    private bool ispause = false;

    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("Volume", volume);
    }

    public void Pause()
    {
        Debug.Log("PauseNew");
        ispause = true;
        Time.timeScale = 0f;
        obj.SetActive(false);
        s.SetActive(false);
        store.SetActive(false);
    }


    public void Resume()
    {
        Debug.Log("Resume");
        ispause = false;
        Time.timeScale = 1f;
        //obj.SetActive(true);
        s.SetActive(true);
        store.SetActive(true);
    }

    public void quit(){
        Application.LoadLevel("Menu");
    }
}

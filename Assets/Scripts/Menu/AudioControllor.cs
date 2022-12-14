using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace menu
{


    public class AudioControllor : MonoBehaviour
    {
        public static AudioControllor instance;
        static AudioSource m_MyAudioSource;
        public AudioClip backGroundMusic;
        public AudioClip Diemusic;

        public AudioClip pausemusic;
        void balanceVolume()
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "LI YANGHANG")
            {
                Debug.Log("balanceVolume");
                m_MyAudioSource.volume = 0.2f;
            }

        }

        void Start()
        {
            instance = this;
            m_MyAudioSource = GetComponent<AudioSource>();
            m_MyAudioSource.loop = true;
            m_MyAudioSource.clip = backGroundMusic;
            balanceVolume();
            m_MyAudioSource.Play();
        }
        public void pauseMusic()
        {
            m_MyAudioSource.Pause();
            m_MyAudioSource.clip = pausemusic;
            m_MyAudioSource.Play();
        }
        public void ResumeMusic()
        {
            m_MyAudioSource.Pause();
            m_MyAudioSource.clip = backGroundMusic;
            balanceVolume();
            m_MyAudioSource.Play();
        }
        public void DieMusic()
        {
            m_MyAudioSource.Stop();
            m_MyAudioSource.clip = Diemusic;
            m_MyAudioSource.loop = false;
            balanceVolume();
            m_MyAudioSource.Play();
        }

        void Update()
        {

        }

    }

}

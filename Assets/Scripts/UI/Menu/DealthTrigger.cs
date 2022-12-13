using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DealthTrigger : MonoBehaviour
{
    BoxCollider2D dt;
    AudioSource audioSource;
    void Start()
    {
        this.transform.parent.gameObject.GetComponent<AudioSource>().Stop();
        dt = GetComponent<BoxCollider2D>();
        audioSource = GameObject.Find("Player").GetComponent<AudioSource>();
        // audioSource.clip = Resources.Load<AudioClip>("Assets/Resources/Sound/levelSound/Vigorous BGM.mp3");
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SceneReload()
    {
        PlayerInfo.getInstance().Reload();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    void OnTriggerEnter2D(Collider2D collidedObject)
    {
        Debug.Log("Trigger");
        if (collidedObject.gameObject.tag == "Player")
        {
            Die();
        }
    }
    private void Die()
    {
        audioSource.Stop();
        this.transform.parent.gameObject.GetComponent<AudioSource>().Play();
        // Time.timeScale = 0f;
        Invoke("SceneReload", 0.3f);
    }
}

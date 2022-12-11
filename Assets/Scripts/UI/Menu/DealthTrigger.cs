using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DealthTrigger : MonoBehaviour
{
    BoxCollider2D dt;
    void Start()
    {
        dt = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SceneReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    void OnTriggerEnter2D(Collider2D collidedObject)
    {
        Debug.Log("Trigger");
        if (collidedObject.gameObject.tag == "Player")
        {
            SceneReload();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelTransfer : MonoBehaviour
{
    private float loadTime = 1.0f;

    private void OnTriggerEnter2D(Collider2D myCollider2d)
    {
        if(myCollider2d.gameObject.CompareTag("Player"))
        {
            Invoke("nextLevel", loadTime);
        }
    }

    private void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
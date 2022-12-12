using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SkullDoor : MonoBehaviour
{
    private bool isPlayerInDoor;
    private Animator anim;
    private float loadTime = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerInDoor)
        {
            anim.SetTrigger("Open");
        }
    }

    private void OnTriggerEnter2D(Collider2D myCollider2d)
    {
        if(myCollider2d.gameObject.CompareTag("Player"))
        {
            isPlayerInDoor = true;
            Invoke("loadLevel", loadTime);
        }
    }

    private void loadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
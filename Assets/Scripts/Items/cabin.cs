using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cabin : MonoBehaviour
{
    public bool level3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collidedObject)
    {
        Debug.Log("Trigger");
        if (collidedObject.gameObject.tag == "Player")
        {
            pass();
        }

    }
    void pass()
    {
        if (!level3)
        {
            SceneManager.LoadScene("L2_work");
        }
        else
        {
            SceneManager.LoadScene("L3_work");
        }
    }
}

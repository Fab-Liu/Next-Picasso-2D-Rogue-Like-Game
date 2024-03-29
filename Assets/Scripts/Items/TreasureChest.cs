using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    private GameObject dialogBox;
    private Animator anim;  //'Open' and 'Close'
    private bool collision;  //Character is within the range of chest
    private bool status;  //Open (true) or close (false)
    public GameObject treasure;
    public float genTime;  //Delay time
    public bool isGen;  //Whether treasure has been generated

    // Start is called before the first frame update
    void Start()
    {
        dialogBox = GameObject.Find("Canvas (1)").transform.Find("BoxDialog").gameObject;
        anim = GetComponent<Animator>();
        status = false;
        isGen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))  //Press 'Q' to open chest
        {
            if (!status && collision)
            {
                anim.SetTrigger("Open");
                status = true;
                if (!isGen)
                {
                    Invoke("GenTreasure", genTime);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D myCollider)
    {
        if (myCollider.gameObject.CompareTag("Player") && myCollider.GetType().ToString() == "UnityEngine.CircleCollider2D")
        {
            collision = true;
            dialogBox.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D myCollider)
    {
        if (myCollider.gameObject.CompareTag("Player") && myCollider.GetType().ToString() == "UnityEngine.CircleCollider2D")
        {
            collision = false;
            anim.SetTrigger("Close");
            status = false;
            dialogBox.SetActive(false);
        }
    }

    void GenTreasure()
    {
        Instantiate(treasure, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
        isGen = true;
    }
}
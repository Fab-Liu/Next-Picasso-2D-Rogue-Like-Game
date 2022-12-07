using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;

public class Billboard : MonoBehaviour
{
    public GameObject dialogbox;
    public Text dialogboxText;
    public string boardContent;
    private bool isInBoard;

    // Start is called before the first frame update
    void Start()
    {
        dialogboxText.text = boardContent;
        dialogbox.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D myCollider2d)
    {        
        if (myCollider2d.gameObject.CompareTag("Player"))
        {
            isInBoard = true;
            dialogbox.SetActive(true);
            Debug.Log("Collision");
        }
    }

    void OnTriggerExit2D(Collider2D myCollider2d)
    {
        if (myCollider2d.gameObject.CompareTag("Player"))
        {
            isInBoard = false;
            dialogbox.SetActive(false);
            Debug.Log("!Collision");
        }   
    }
}
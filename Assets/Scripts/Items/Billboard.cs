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
            dialogbox.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D myCollider2d)
    {
        if (myCollider2d.gameObject.CompareTag("Player"))
        {
            dialogbox.SetActive(false);
        }   
    }
}
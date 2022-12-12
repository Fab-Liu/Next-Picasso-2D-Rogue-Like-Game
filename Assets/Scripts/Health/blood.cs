using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blood : MonoBehaviour
{
    public Image img;
    public float time;
    public Color flash;

    private Color none;

    // Start is called before the first frame update
    void Start()
    {
        none = img.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlashScreen()
    {
        Debug.Log("Flashing");
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        Debug.Log("flash work");
        img.color = flash;
        yield return new WaitForSeconds(time);
        img.color = none;
    }
}

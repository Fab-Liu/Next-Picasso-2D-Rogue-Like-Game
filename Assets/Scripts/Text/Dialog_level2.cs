using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog_level2 : MonoBehaviour
{
    //public Text speech;
    public Text button;
    public TextMeshProUGUI Text;
    public GameObject speech;
    public GameObject btn;

    private int index = 1;

    // Start is called before the first frame update
    void Start()
    {
        Text = speech.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (index == 1)
        {
            //修改btn文字
            button.text = "You AGAIN ??!!!";
            //修改speech
            Text.text = "Hey!Here I come!!Surprise!!";
        }

        if (index == 2)
        {
            //修改btn文字
            button.text = "What is it?";
            //修改speech
            Text.text = "This is the last of journey!I am here to give you some tips!";
        }

        if (index == 3)
        {
            button.text = "Sure!I will take care!";
            Text.text = "Be careful!!!There are gaps on the group,don't fall from it!";
        }


        if (index == 4)
        {
            button.text = "I will save the town!";
            Text.text = "So let's continue your journey!Good luck to you!";
            Invoke("desDialog", 1f);
        }

        if (index == 5)
        {
            desDialog();
        }
    }

    public void Next()
    {
        index++;
        Debug.Log("index = " + index);
    }

    void desDialog()
    {
        Debug.Log("here is working~~~");
        Destroy(this.gameObject);
        Time.timeScale = 1f;
    }
}

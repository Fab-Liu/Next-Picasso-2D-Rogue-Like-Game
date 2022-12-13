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

    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
       Text = speech.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (index == 1) {
            //修改btn文字
            button.text = "Wow, thank you!";
            //修改speech
            Text.text = "speach 1 ................................................................................";
        }
        
        if (index == 2) {
            //修改btn文字
            button.text = "What can I do with it?";
            //修改speech
            Text.text = "speach 2 ................................................................................";
        }

        if (index == 2) {
            button.text = "But this hammer sucks.";
            Text.text = "speach 3 ................................................................................";
        }

        if (index == 3) {
            button.text = "That`s great!";
            Text.text = "speach 4 ................................................................................";
        }

        if (index == 3) {
            button.text = "I will save the town!";
            Text.text = "speach 5 ................................................................................";
            Invoke("desDialog", 2f);
        }

        if(index == 4){
            desDialog();
        }
    }

    public void Next2(){
        index++;
        Debug.Log("index = " + index);
    }

    void desDialog(){
        Debug.Log("here is working~~~");
        Destroy(this.gameObject);
        Time.timeScale = 1f;
    }
}

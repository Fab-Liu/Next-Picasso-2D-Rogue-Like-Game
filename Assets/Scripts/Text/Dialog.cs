using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog : MonoBehaviour
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
            Text.text = "Considering that you have been away from home for a long time. So I arranged some hints around the screen.";
        }
        
        if (index == 2) {
            //修改btn文字
            button.text = "What can I do with it?";
            //修改speech
            Text.text = "Be careful, these wizards are cunning. They have arranged a lot of little monsters nearby.";
            // But don't worry too much, I believe that with your strength, you can kill them with one blow.
        }

        if (index == 2) {
            button.text = "But this hammer sucks.";
            Text.text = "You don't need worry too much, I believe you can kill with one blow.";
        }

        if (index == 3) {
            button.text = "That`s great!";
            Text.text = "Oh my boy, watch out, there are magic learning points on the way. You can get the magic you need there.";
        }

        if (index == 3) {
            button.text = "I will save the town!";
            Text.text = "Come on boy, the future of our hometown depends on you.";
            Invoke("desDialog", 2f);
        }

        if(index == 4){
            desDialog();
        }
    }

    public void Next(){
        index++;
        Debug.Log("index = " + index);
    }

    void desDialog(){
        Debug.Log("here is working~~~");
        Destroy(this.gameObject);
        Time.timeScale = 1f;
    }
}

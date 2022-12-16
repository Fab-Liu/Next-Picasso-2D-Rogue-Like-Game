using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class magic_inc : MonoBehaviour
{
        //magic和无敌模式
    public TextMeshProUGUI txt_m1;
    public TextMeshProUGUI txt_m2;
    public TextMeshProUGUI txt_m3;
    public TextMeshProUGUI txt_inc;

    public static int m1 = 0;
    public static int m2 = 0;
    public static int m3 = 0;
    public static int inc = 0;

    public magic_inc(){

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txt_m1.text = m1.ToString();
        txt_m2.text = m2.ToString();
        txt_m3.text = m3.ToString();
        txt_inc.text = inc.ToString();
    }

    public bool minusM1(){
        if(m1 != 0){
            Debug.Log("minus is working");
            m1--;
            txt_m1.text = m1.ToString();
            return true;
        }else{
            return false;
        }
    }

    public bool minusM2(){
        if(m2 != 0){
            m2--;
            txt_m2.text = m2.ToString();
            return true;
        }else{
            return false;
        }
    }

    public bool minusM3(){
        if(m3 != 0){
            m3--;
            txt_m3.text = m3.ToString();
            return true;
        }else{
            return false;
        }
    }

    public bool minusInc(){
        if(inc != 0){
            inc--;
            txt_inc.text = inc.ToString();
            return true;
        }else{
            return false;
        }
    }
}

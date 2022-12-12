using System.Collections;
using System.Collections.Generic;
using Text = TMPro.TextMeshProUGUI;
using UnityEngine;
using UnityEngine.UI;

public class DiamondUI : MonoBehaviour
{
    public int initDiamondNum;
    public Text diamondNum;
    public static int currentDiamondNum;

    // Start is called before the first frame update
    void Start()
    {
        currentDiamondNum = initDiamondNum;
    }

    // Update is called once per frame
    void Update()
    {
        diamondNum.text = currentDiamondNum.ToString();
    }
}
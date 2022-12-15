using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuLevel2 : MonoBehaviour
{
    public Button ExitButton;
    public Button NextButton;

    // Start is called before the first frame update
    void Start()
    {
        ExitButton.onClick.AddListener(exitFunc);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void exitFunc()
    {
        // Load the select scene
        Application.LoadLevel("Menu");
    }

    public void loadToLevel1()
    {
        // Load the level 1 scene
        Application.LoadLevel("Level2");
    }

}
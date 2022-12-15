using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLevel1 : MonoBehaviour
{
    public Button ExitButton;
    public Button NextButton;

    // Start is called before the first frame update
    void Start()
    {
        ExitButton.onClick.AddListener(exitFunc);
        NextButton.onClick.AddListener(loadToLevel2);
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

    public void loadToLevel2()
    {
        // Load the level 2 scene
        Application.LoadLevel("Level2");
    }

}
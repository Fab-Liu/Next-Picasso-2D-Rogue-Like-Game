using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelectButton : MonoBehaviour
{
    public Button Level1Button;
    public Button Level2Button;
    public Button Level3Button;

    // Start is called before the first frame update
    void Start()
    {
        Level1Button.onClick.AddListener(loadToLevel1);
        Level2Button.onClick.AddListener(loadToLevel2);
        Level3Button.onClick.AddListener(loadToLevel3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void userSelect()
    {
        // Load the select scene
        Application.LoadLevel("Select");
    }

    public void loadToLevel1()
    {
        // Load the level 1 scene
        Application.LoadLevel("Level1");
    }

    public void loadToLevel2()
    {
        // Load the level 2 scene
        Application.LoadLevel("Level2");
    }

    public void loadToLevel3()
    {
        // Load the level 3 scene
        Application.LoadLevel("Level3");
    }
}
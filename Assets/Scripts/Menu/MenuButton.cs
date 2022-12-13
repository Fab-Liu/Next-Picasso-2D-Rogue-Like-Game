using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public Button PlayButton;

    // Start is called before the first frame update
    void Start()
    {
        PlayButton.onClick.AddListener(userSelect);
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
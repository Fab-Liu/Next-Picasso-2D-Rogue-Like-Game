using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInfo
{
    private static PlayerInfo instance;

    public int money = 100;

    public PlayerInfo()
    {

    }

    // // Start is called before the first frame update
    // void Awake()
    // {
    //     money = 100;
    // }
    // void Start()
    // {

    // }


    public static PlayerInfo getInstance()
    {
        if (instance == null)
        {
            instance = new PlayerInfo();
        }
        return instance;
    }

    public void Reload()
    {
        money = 100;
    }

    
}


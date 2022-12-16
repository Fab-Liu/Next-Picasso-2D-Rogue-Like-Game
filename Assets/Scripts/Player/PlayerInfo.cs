using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInfo
{
    private static PlayerInfo instance;

    public int money = 20;

    public PlayerInfo()
    {

    }


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
        money = 20;
    }


}


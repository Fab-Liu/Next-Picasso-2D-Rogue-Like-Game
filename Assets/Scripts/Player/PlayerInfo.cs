using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    private static PlayerInfo instance;

    public int money = 100;
    private PlayerInfo()
    {

    }

    // Start is called before the first frame update
    void Awake()
    {
        money = 100;
    }
    void Start()
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
}


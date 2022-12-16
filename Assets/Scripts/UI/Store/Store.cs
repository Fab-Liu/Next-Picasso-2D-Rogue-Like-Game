using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    private int itemPrice1 = 10;
    private int itemPrice2 = 20;
    private GameObject cell1;
    private GameObject cell2;
    private GameObject cell3;
    private GameObject cell4;
    private GameObject cell5;
    private GameObject cell6;
    private Button close;
    private PlayerInfo playerInfo;
    private GameObject info;
    private GameObject me;
    private GameObject InGameUI;
    private Text balance;
    private AudioSource audioSource;

    //Buy extra health
    public GameObject bar;
    private PlayerHealthBar playerHealthBar;

    private void Awake()
    {
        playerInfo = PlayerInfo.getInstance();
    }
    void Start()
    {
        Debug.Log("Store Start");
        playerInfo = PlayerInfo.getInstance();
        cell1 = transform.Find("StoreCell(1)").gameObject;
        cell2 = transform.Find("StoreCell(2)").gameObject;
        cell3 = transform.Find("StoreCell(3)").gameObject;
        cell4 = transform.Find("StoreCell(4)").gameObject;
        cell5 = transform.Find("StoreCell(5)").gameObject;
        cell6 = transform.Find("StoreCell(6)").gameObject;
        setCell1();
        setCell2();
        close = transform.Find("Close").GetComponent<Button>();
        close.onClick.AddListener(Close);
        info = transform.Find("Info").gameObject;
        info.SetActive(false);
        InGameUI = GameObject.Find("Canvas (1)").transform.Find("InGameUI").gameObject;
        balance = transform.Find("Balance").GetComponent<Text>();
        balance.text = "Balance:" + playerInfo.money.ToString();
        audioSource = GetComponent<AudioSource>();

        //Buy extra health
        playerHealthBar = bar.GetComponentInChildren<PlayerHealthBar>();
    }
    void Update()
    {
        balance.text = "Balance:" + playerInfo.money.ToString();
    }
    private void addMoney(int amount)
    {
        playerInfo.money += amount;
        balance.text = "Balance:" + playerInfo.money.ToString();
    }
    private void DeduceMoney(int amount)
    {
        playerInfo.money -= amount;
        balance.text = "Balance:" + playerInfo.money.ToString();
    }
    private void setCell1()
    {
        cell1.transform.Find("Buy").GetComponent<Button>().onClick.AddListener(BuyCell1);
    }
    private void BuyCell1()
    {
        if (playerInfo.money < itemPrice1)
        {
            setInfoAndDisplay("Not Enough Money");
            return;
        }
        DeduceMoney(itemPrice1);

        //Add extra health-customizable
        playerHealthBar.AddHealth(2);

        setInfoAndDisplay("Buy Scuccessfully");
    }
    private void setCell2()
    {
        // cell2.transform.Find("CellTitle").GetComponent<Text>().text = "Cell2";
        // cell2.transform.Find("Size").GetComponent<Text>().text = "Large";
        // cell2.transform.Find("Description").GetComponent<Text>().text = "Cell2 Description";
        // cell2.transform.Find("Price").GetComponent<Text>().text = "100";
        cell2.transform.Find("Buy").GetComponent<Button>().onClick.AddListener(BuyCell2);
    }
    private void BuyCell2()
    {
        if (playerInfo.money < itemPrice2)
        {
            setInfoAndDisplay("Not Enough Money");
            return;
        }
        DeduceMoney(itemPrice2);

        //Add extra health-customizable
        playerHealthBar.AddHealth(5);

        setInfoAndDisplay("Buy Scuccessfully");
    }
    private void Close()
    {
        GameObject.Find("Canvas (1)").transform.Find("bg_stop").gameObject.SetActive(false);
        gameObject.SetActive(false);
        InGameUI.SetActive(true);
    }
    private void setInfoAndDisplay(string title)
    {
        // audioSource.clip = Resources.Load<AudioClip>("Assets/Resources/Sound/Money.wav");
        audioSource.Play();
        info.transform.Find("Text").GetComponent<Text>().text = title;
        info.SetActive(true);
        DisapperAsync();
    }
    private async void DisapperAsync()
    {
        await Task.Delay(1000);
        info.SetActive(false);
    }
    private void setCell3()
    {
        cell3.transform.Find("Buy").GetComponent<Button>().onClick.AddListener(BuyCell3);
    }
    private void setCell4()
    {
        cell4.transform.Find("Buy").GetComponent<Button>().onClick.AddListener(BuyCell4);
    }
    private void setCell5()
    {
        cell5.transform.Find("Buy").GetComponent<Button>().onClick.AddListener(BuyCell5);
    }
    private void setCell6()
    {
        cell6.transform.Find("Buy").GetComponent<Button>().onClick.AddListener(BuyCell6);
    }

    private void BuyCell3()
    {
        if (playerInfo.money < itemPrice2)
        {
            setInfoAndDisplay("Not Enough Money");
            return;
        }
        DeduceMoney(itemPrice2);

        //Add extra health-customizable
        playerHealthBar.AddHealth(5);

        setInfoAndDisplay("Buy Scuccessfully");
    }
    private void BuyCell4()
    {
        if (playerInfo.money < itemPrice2)
        {
            setInfoAndDisplay("Not Enough Money");
            return;
        }
        DeduceMoney(itemPrice2);

        //Add extra health-customizable
        playerHealthBar.AddHealth(5);

        setInfoAndDisplay("Buy Scuccessfully");
    }
    private void BuyCell5()
    {
        if (playerInfo.money < itemPrice2)
        {
            setInfoAndDisplay("Not Enough Money");
            return;
        }
        DeduceMoney(itemPrice2);

        //Add extra health-customizable
        playerHealthBar.AddHealth(5);

        setInfoAndDisplay("Buy Scuccessfully");
    }
    private void BuyCell6()
    {
        if (playerInfo.money < itemPrice2)
        {
            setInfoAndDisplay("Not Enough Money");
            return;
        }
        DeduceMoney(itemPrice2);

        //Add extra health-customizable
        playerHealthBar.AddHealth(5);

        setInfoAndDisplay("Buy Scuccessfully");
    }





}

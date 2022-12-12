using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    private GameObject storeObj;
    private Button storeBtn;
    private Button pauseBtn;
    private GameObject me;
    // Start is called before the first frame update
    private Text coinText;


    void Start()
    {
        storeObj = GameObject.Find("Canvas (1)").transform.Find("Store").gameObject;
        storeObj.SetActive(false);
        storeBtn = transform.Find("StoreButton").GetComponent<Button>();
        storeBtn.onClick.AddListener(OpenStore);
        pauseBtn = transform.Find("PauseButton").GetComponent<Button>();
        pauseBtn.onClick.AddListener(PauseGame);
        me = GameObject.Find("Canvas (1)").transform.Find("InGameUI").gameObject;
        coinText = transform.Find("Balance/money").GetComponent<Text>();
    }
    void Update()
    {
        coinText.text = PlayerInfo.getInstance().money.ToString();
    }

    private void PauseGame()
    {

    }

    public void OpenStore()
    {
        storeObj.SetActive(true);
        me.SetActive(false);

    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPool : MonoBehaviour
{
    public static ShadowPool instance;

    public GameObject shadowPrefab;

    public int shadowCount;

    // 队列
    private Queue<GameObject> availableObjects = new Queue<GameObject>();

    void Awake()
    {
        instance = this;

        shadowPrefab = Resources.Load("Shadow") as GameObject;

        //初始化对象池
        FillPool();
    }


    public void FillPool()
    {
        for (int i = 0; i < shadowCount; i++)
        {
            var newShadow = Instantiate(shadowPrefab);
            newShadow.transform.SetParent(transform);


            ReturnPool(newShadow);
        }
    }

    public void ReturnPool(GameObject gameObject)
    {
        gameObject.SetActive(false);

        //Enqueue 添加到队列末尾
        availableObjects.Enqueue(gameObject);
    }

    public GameObject GetFromPool()
    {
        if (availableObjects.Count == 0)
        {
            FillPool();
        }

        //Dequeue 抽出队列第一个
        var outShadow = availableObjects.Dequeue();

        outShadow.SetActive(true);

        return outShadow;
    }


}

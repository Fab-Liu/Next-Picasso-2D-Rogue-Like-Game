using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
namespace Diemenu
{
    public class DieMenu : MonoBehaviour
    {
        private GameObject total;
        private Button restart;
        private

        void Start()
        {
            total = transform.Find("Total").gameObject;
            total.SetActive(false);
            restart = total.transform.Find("Restart").GetComponent<Button>();
            restart.onClick.AddListener(() => { reloadScene(); });
        }

        static public void DieMenuShow()
        {
            Time.timeScale = 0f;
            GameObject canvas = GameObject.Find("Canvas (1)");
            canvas.transform.Find("bg_stop").gameObject.SetActive(true);
            GameObject dieMenu = GameObject.Find("Canvas (1)/DieMenu");
            GameObject total = dieMenu.transform.Find("Total").gameObject;
            total.SetActive(true);
            ArrayList al = buildList();
            total.transform.Find("Tip").GetComponent<TMP_Text>().text = "Tips:" + al[Random.Range(0, al.Count)];
            Button restart = total.transform.Find("Restart").GetComponent<Button>();
            restart.onClick.AddListener(() => { reloadScene(); });
        }
        static private ArrayList buildList()
        {
            ArrayList al = new ArrayList();
            al.Add("Use you weapon to kill the enemy");
            al.Add("Avoid the enemy's attack");
            al.Add("Buy some goods in the store");
            return al;
        }
        static void reloadScene()
        {
            PlayerInfo.getInstance().Reload();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }
    }
}


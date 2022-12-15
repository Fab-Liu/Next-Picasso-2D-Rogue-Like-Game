using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace Diemenu
{
    public class DieMenu : MonoBehaviour
    {
        private GameObject total;
        private Button restart;

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

            Button restart = total.transform.Find("Restart").GetComponent<Button>();
            restart.onClick.AddListener(() => { reloadScene(); });
        }
        static void reloadScene()
        {
            PlayerInfo.getInstance().Reload();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }
    }
}


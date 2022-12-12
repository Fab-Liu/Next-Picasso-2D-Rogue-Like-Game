// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.Audio;
// using UnityEngine.UI;
// using System.Threading;
// namespace menu
// {
//     public class core : MonoBehaviour
//     {
//         private bool ispause = false;
//         public bool inscene;
//         public bool NeedDieOperation;
//         public bool isAofanScene;
//         public AudioMixer audioMixer;
//         // Toggle muteToggle;
//         // GameObject pauseMenu;
//         GameObject dieMenu;

//         GameObject dieNew;
//         // [SerializeField]
//         // protected Animator animator;
//         GameObject pauseTotalNew;

//         void Start()
//         {
//             // Debug.Log("Start");
//             if (inscene == true)
//             {
//                 if (!this.isAofanScene)
//                 {
//                     pauseTotalNew = GameObject.Find("Canvas/PauseTotalNew");
//                 }
//                 else
//                 {
//                     pauseTotalNew = GameObject.Find("Canvas (1)/PauseTotalNew");

//                 }
//                 pauseTotalNew.transform.Find("PauseMenu").gameObject.SetActive(false);

//             }
//             if (NeedDieOperation == true)
//             {
//                 GameObject dieTotal;
//                 if (!this.isAofanScene)
//                 {
//                     dieTotal = GameObject.Find("Canvas/DieTotal");
//                 }
//                 else
//                 {
//                     dieTotal = GameObject.Find("Canvas (1)/DieTotal");
//                 }
//                 dieMenu = dieTotal.transform.Find("DieMenu").gameObject;
//                 dieMenu.SetActive(false);

//             }

//         }

//         void Update()
//         {
//             if (Input.GetKeyDown(KeyCode.Escape))
//             {
//                 if (ispause)
//                 {
//                     ResumeNew();
//                 }
//                 else
//                 {
//                     PauseNew();
//                 }

//             }
//         }
//         public void sellectLevel()
//         {
//             // Debug.Log("sellectLevel");
//             SceneManager.LoadScene("LevelSelector");
//         }

//         public void Level1()
//         {
//             SceneManager.LoadScene("SU YANYU");

//         }
//         public void Level2()
//         {
//             SceneManager.LoadScene("LIU AOFAN");

//         }
//         public void Level3()
//         {
//             SceneManager.LoadScene("LI YANGHANG");
//         }
//         public void Level4()
//         {

//             SceneManager.LoadScene("TAN QIANQIAN");
//         }
//         public void Level5()
//         {
//             SceneManager.LoadScene("ZENG ZIYI");
//         }
//         public void main_menu()
//         {

//             // Thread.Sleep(1000);
//             Time.timeScale = 1;
//             SceneManager.LoadScene("Main_menu");
//         }
//         public void QuitGame()
//         {
//             Debug.Log("Quit");
// #if UNITY_EDITOR
//             UnityEditor.EditorApplication.isPlaying = false;
// #else
//         Application.Quit();
// #endif
//         }
//         // public void Pause()
//         // {
//         //     Debug.Log("Pause");

//         //     if (pauseMenu == null)
//         //     {
//         //         Debug.Log("menu is null666");
//         //         return;
//         //     }
//         //     pauseMenu.SetActive(true);

//         //     Time.timeScale = 0f;
//         // }

//         public void PauseNew()
//         {
//             Debug.Log("PauseNew");
//             ispause = true;
//             pauseTotalNew.transform.Find("PauseMenu").gameObject.SetActive(true);
//             AudioControllor.instance.pauseMusic();
//             Time.timeScale = 0f;
//         }

//         // void Resume()
//         // {
//         //     Debug.Log("Resume");
//         //     pauseMenu.SetActive(false);
//         //     Time.timeScale = 1f;
//         // }
//         public void ResumeNew()
//         {
//             Debug.Log("Resume");
//             ispause = false;
//             pauseTotalNew.transform.Find("PauseMenu").gameObject.SetActive(false);
//             AudioControllor.instance.ResumeMusic();
//             Time.timeScale = 1f;
//         }
//         public void SetVolume(float volume)
//         {
//             // Debug.Log(volume);
//             audioMixer.SetFloat("Volume", volume);
//         }

//         // public void Mute()
//         // {
//         //     if (muteToggle.isOn == true)
//         //     {
//         //         audioMixer.SetFloat("Volume", -80f);
//         //         Debug.Log("Mute");
//         //     }
//         //     else
//         //     {
//         //         audioMixer.SetFloat("Volume", 0f);
//         //         Debug.Log("Unmute");
//         //     }

//         // }
//         public void SceneReload()
//         {
//             GameObject.Find("Canvas").transform.Find("blood").gameObject.SetActive(false);
//             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//             Time.timeScale = 1f;
//         }
//         static public void Die()
//         {
//             AudioControllor.instance.DieMusic();
//             GameObject.Find("Canvas").transform.Find("blood").gameObject.SetActive(false);
//             Time.timeScale = 0f;
//             DieMenu();
//         }
//         static public void DieForAofanScene()
//         {

//             AudioControllor.instance.DieMusic();
//             Time.timeScale = 0f;
//             DieMenuForAofan();
//         }

//         static void DieMenu()
//         {
//             GameObject dieTotal;
//             dieTotal = GameObject.Find("Canvas/DieTotal");
//             dieTotal.transform.Find("DieMenu").gameObject.SetActive(true);
//             Time.timeScale = 0f;
//         }
//         static void DieMenuForAofan()
//         {
//             GameObject dieTotal;
//             dieTotal = GameObject.Find("Canvas (1)/DieTotal");
//             dieTotal.transform.Find("DieMenu").gameObject.SetActive(true);
//             Time.timeScale = 0f;
//         }
//     }
// }


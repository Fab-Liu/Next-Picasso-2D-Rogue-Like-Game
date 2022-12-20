using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalMenu : MonoBehaviour
{

    public void QuitGame()
    {
            Debug.Log("Quit");
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
    }

    public void back(){
        Application.LoadLevel("Menu");
    }
}

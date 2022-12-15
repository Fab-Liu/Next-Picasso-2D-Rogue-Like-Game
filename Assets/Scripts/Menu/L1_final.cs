using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1_final : MonoBehaviour
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

    public void next(){
        Application.LoadLevel("Level2");
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_SceneSwitcher : MonoBehaviour
{
    public void sceneSwitcher(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void onQuit()
    {
        Application.Quit();
        Debug.Log("Jeu Quitté");
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_SceneSwitcher : MonoBehaviour
{
    public void toMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void toGame()
    {
        SceneManager.LoadScene(1);
    }

    public void toControls()
    {
        SceneManager.LoadScene(2);
    }
    
    public void toCredits()
    {
        SceneManager.LoadScene(3);
    }

    public void onQuit()
    {
        Application.Quit();
    }
}

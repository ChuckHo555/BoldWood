using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void onStartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void onExitButton()
    {
        Application.Quit();
    }

    public void OnRestart(int layerIndex)
    {
        SceneManager.LoadScene(1);
    }

    public void onMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}

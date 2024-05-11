using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void StartChildPhase()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void StartTeenPhase()
    {
        SceneManager.LoadSceneAsync(4);
    }

    public void StartAdultPhase()
    {
        SceneManager.LoadSceneAsync(6);
    }

    public void StartOldPhase()
    {
        SceneManager.LoadSceneAsync(8);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void PlayAgain()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void OnApplicationQuit()
    {
       Application.Quit();
    }
}

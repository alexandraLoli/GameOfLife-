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

    public void Skip()
    {
        SceneManager.LoadSceneAsync(5);
    }

    public void StartChapter1()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void StartChapter2()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void StartChapter3()
    {
        SceneManager.LoadSceneAsync(4);
    }
    public void StartChapter4()
    {
        SceneManager.LoadSceneAsync(5);
    }


    public void StartChildPhase()
    {
        SceneManager.LoadSceneAsync(6);
    }

    public void StartTeenPhase()
    {
        SceneManager.LoadSceneAsync(8);
    }

    public void StartAdultPhase()
    {
        SceneManager.LoadSceneAsync(10);
    }

    public void StartOldPhase()
    {
        SceneManager.LoadSceneAsync(12);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void PlayAgain()
    {
        SceneManager.LoadSceneAsync(5);
    }

    public void OnApplicationQuit()
    {
       Application.Quit();
    }
}

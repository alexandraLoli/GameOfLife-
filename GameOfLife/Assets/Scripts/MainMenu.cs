using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioManager audioManager;

    public void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
   public void PlayGame()
    {
        PlayClickSound();
        SceneManager.LoadSceneAsync(1);
    }

    public void Skip()
    {
        PlayClickSound();
        SceneManager.LoadSceneAsync(5);
    }

    public void StartChapter1()
    {
        PlayClickSound();
        SceneManager.LoadSceneAsync(2);
    }

    public void StartChapter2()
    {
        PlayClickSound();
        SceneManager.LoadSceneAsync(3);
    }

    public void StartChapter3()
    {
        PlayClickSound();
        SceneManager.LoadSceneAsync(4);
    }
    public void StartChapter4()
    {
        PlayClickSound();
        SceneManager.LoadSceneAsync(5);
    }


    public void StartChildPhase()
    {
        SceneManager.LoadSceneAsync(7);
    }

    public void StartTeenPhase()
    {
        SceneManager.LoadSceneAsync(9);
    }

    public void StartAdultPhase()
    {
        SceneManager.LoadSceneAsync(11);
    }

    public void StartOldPhase()
    {
        SceneManager.LoadSceneAsync(13);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void PlayAgain()
    {
        PlayClickSound();
        SceneManager.LoadSceneAsync(6);
    }

    public void OnApplicationQuit()
    {
        PlayClickSound();
       Application.Quit();
    }
    private void PlayClickSound()
    {
        if (audioManager != null)
        {
            audioManager.PlayClickSound();
        }
    }
}

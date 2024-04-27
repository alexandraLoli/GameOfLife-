using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    // Start is called before the first frame update
    private float gameTime;
    public int stage;

    void Start()
    {
        
        if (stage == 1)
        {
            gameTime = 60;
        }
        else if (stage == 2)
        {
            gameTime = 120;
        }
        else if (stage == 3)
        {
            gameTime = 180;
        }
        else if (stage == 4)
        {
            gameTime = 240;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTime <= 0 && stage != 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } 
        else if (gameTime <= 0 && stage == 4)
        {
            SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
        }

        gameTime -= Time.deltaTime;
    }
}

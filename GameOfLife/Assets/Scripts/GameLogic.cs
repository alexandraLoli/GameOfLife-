using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    // Start is called before the first frame update

    // timer for each stage
    private float gameTime;

    // vairable to identify the stage
    public int stage;

    // variables to get money
    public GameObject moneySign;
    private float moneyInterval = 10;

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


        if (moneyInterval <= 0)
        {
            SendMoney();
            moneyInterval = 10;
        }

        moneyInterval -= Time.deltaTime;

        gameTime -= Time.deltaTime;
    }

    private void SendMoney()
    {
        if (moneySign != null)
        {
            int randomX, randomY;
            randomX = Random.Range(-8, 8);
            randomY = Random.Range(-4, 3);

            GameObject newProjectile = Instantiate(moneySign, new Vector3(randomX, randomY, 0), Quaternion.identity);
            Rigidbody2D projectileRB = newProjectile.GetComponent<Rigidbody2D>();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
 * 
 * This class is used to take care of the Avatar's gender,
 * to check the ending of each phase when the gameTime ended,
 * and to send money to the player
 * 
 */
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
    private MoneyBehavior moneyBehaviorScript;

    // variable to interact with total currency
    private Money script;
    public GameObject canvas;

    // variables for friend helper
    public GameObject boy;
    public GameObject boyBust;
    public GameObject girl;
    public GameObject girlBust;

    // variables to stop enemies from coming
    public GameObject enemyObject;
    private SpwanEnemy spawnEnemyScript;

    void Start()
    {
        // valuable scripts / classes
        script = canvas.GetComponent<Money>();
        moneyBehaviorScript = moneySign.GetComponent<MoneyBehavior>();
        spawnEnemyScript = enemyObject.GetComponent<SpwanEnemy>();

        /*
         *  Here we set the value for : 
         *  
         *      gameTime - how long will last this life phase
         *      value = how many money will the player get when they click on the dollar sign
         *      minRange / maxRange - the interval for the amount of money received in the beginning
         *      
         *  for each phase of life
         */
        if (stage == 1)
        {
            gameTime = 90;
            moneyBehaviorScript.value = 50;
            script.minRange = 100;
            script.maxRange = 150;
        }
        else if (stage == 2)
        {
            gameTime = 140;
            moneyBehaviorScript.value = 100;
            script.minRange = 100;
            script.maxRange = 200;
        }
        else if (stage == 3)
        {
            gameTime = 200;
            moneyBehaviorScript.value = 150;
            script.minRange = 200;
            script.maxRange = 250;
        }
        else if (stage == 4)
        {
            gameTime = 140;
            moneyBehaviorScript.value = 100;
            script.minRange = 250;
            script.maxRange = 350;
        }

        // To show the first amount of money
        script.calculateMoney();

        // Here we show the Avatar corresponding to the gender that the player chose
        if (PlayerGender.Gender.Equals("Girl"))
        {
            boy.GetComponent<Renderer>().enabled = false;
            boyBust.GetComponent<Renderer>().enabled = false;
            girl.GetComponent<Renderer>().enabled = false;
            girlBust.GetComponent<Renderer>().enabled = true;
            boy.GetComponent<Collider2D>().enabled = false;
        } 
        else if (PlayerGender.Gender.Equals("Boy"))
        {
            boy.GetComponent<Renderer>().enabled = false;
            boyBust.GetComponent<Renderer>().enabled = true;
            girl.GetComponent<Renderer>().enabled = false;
            girlBust.GetComponent<Renderer>().enabled = false;
            girl.GetComponent <Collider2D>().enabled = false;   
        }
    }

    // Update is called once per frame
    void Update()
    {
        // a phase is finished and the next one begins
        if (gameTime <= 0 && stage != 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } 

        // the game ended, so the good ending is shown
        else if (gameTime <= 0 && stage == 4)
        {
            SceneManager.LoadScene(15);
        }

        // send money to player
        if (moneyInterval <= 0)
        {
            SendMoney();
            moneyInterval = 15;
        }

        // there's a cool off between the appearance of the last enemy and the end of the phase
        if(gameTime <= 40)
        {
            spawnEnemyScript.stop = true;
        }

        moneyInterval -= Time.deltaTime;

        gameTime -= Time.deltaTime;
    }

    /*
     *  This method makes the dollar sign appear on the scene at a random place
     */
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

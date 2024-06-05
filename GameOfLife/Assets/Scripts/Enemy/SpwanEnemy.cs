using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This clas describes just the way the enemies appear on the scene during the game
 */


// NOTE!! Sounds can be added when a function is called
public class SpwanEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    // variables for spawning
    public int stage;
    public List<GameObject> enemies;
    private Vector3 spawnPoint;
    private int minLimit;
    private int maxLimit;
    private float spawnTime = 0;

    private bool stopRandomEnemies = false;

    // variables for accidents
    private int minLimitAccident;
    private int maxLimitAccident;
    private float spawnTimeAccident = 0;
    private bool moreAccidents = false;
    private int nrOfEnemies;

    // variables for multiple spawning
    private float spawnTimeMultiple = 50;

    // variables for BigBoss
    public GameObject BigBoss;
    private float spawnBigBoss = 100;
    private bool stopBigBoss = false;

    // variable to stop enemies from coming
    public bool stop = false;
    
    void Start()
    {
        /*
         * The Child Phase has a simpler / easier way of spawning the enemies
         * The other phases have something that's called Multiple spawning
         * Because of this, each interval for spawning is different
         */
        if (stage == 0)
        {
            minLimit = 4;
            maxLimit = 6;

            minLimitAccident = 30;
            maxLimitAccident= 40;
        }
        else
        {
            minLimit = 10;
            maxLimit = 12;

            minLimitAccident = 55;
            maxLimitAccident = 60;
        }

        if(stage == 1 || stage == 3)
        {
            nrOfEnemies = 7;

        } 
        
        // just to complicate a bit, on AdultPhase, more enemies come at once
        else if (stage == 2)
        {
            nrOfEnemies = 10;
        }

        // set the spawn time
        spawnTime = Random.Range(5, 10);
        spawnTimeAccident = Random.Range(minLimitAccident, maxLimitAccident);

        // in Teen phase and Old phase, it can happen to have more accidents
        if (stage != 0 || stage != 2)
        {
            int aux = Random.Range(1, 2);
            if (aux == 1)
            {
                moreAccidents = true;
            }
            else
            {
                moreAccidents = false;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        // stop is used to have a cool off between stages
        if (!stop)
        {
            // different spawning type per stage
            if (stage == 0)
            {
                if (spawnTime <= 0)
                {
                    SpwanRandomEnemy();
                    spawnTime = Random.Range(minLimit, maxLimit);
                }

                spawnTime -= Time.deltaTime;
            }
            else
            {
                if (spawnTime <= 0 && !stopRandomEnemies)
                {
                    SpwanRandomEnemy();
                    spawnTime = Random.Range(minLimit, maxLimit);
                }

                if(spawnTimeMultiple <= 0)
                {
                    SpawnALotOfEnemies();
                    spawnTimeMultiple = 50;
                    if (stage != 2)
                    {
                        spawnTime = Random.Range(minLimit, maxLimit);
                    } else
                    {
                        stopRandomEnemies = true;
                    }
                }

                spawnTime -= Time.deltaTime;
                spawnTimeMultiple -= Time.deltaTime;

            }

            // for each stage, accidents come differently 
            if (spawnTimeAccident <= 0)
            {
                SpawnAccident();
                if (moreAccidents)
                {
                    spawnTimeAccident = Random.Range(minLimitAccident - 15, maxLimitAccident - 15);
                } else
                {
                    spawnTimeAccident = Random.Range(minLimitAccident, maxLimitAccident);
                }
            }

            // at adult phase, there's a big enemy
            if (stage == 2)
            {
                if (spawnBigBoss <= 0 && !stopBigBoss)
                {
                    SpawnBigBoss();
                    stopBigBoss = true;
                }

                spawnBigBoss -= Time.deltaTime;
            }


            spawnTimeAccident -= Time.deltaTime;
        }
    }

    // function used to spawn one enemy at random times
    public void SpwanRandomEnemy()
    {
        int randomIndex = Random.Range(0, enemies.Count - 3);
        GameObject pref = enemies[randomIndex];

        int randomLine = Random.Range(0, 30);

        if (randomLine % 3 == 0)
        {
            spawnPoint = new Vector3(9.5f, 1.2f, 1.0f);
        } 
        else if  (randomLine % 3 == 2)
        {
            spawnPoint = new Vector3(9.5f, -1.1f, 1.0f);
        } 
        else if (randomLine % 3 ==  1)
        {
            spawnPoint = new Vector3(9.5f, -3.3f, 1.0f);
        }


        GameObject newEnemy = Instantiate(pref, spawnPoint, Quaternion.identity);
    
        Rigidbody2D enemyRB = newEnemy.GetComponent<Rigidbody2D>();

        enemyRB.velocity = new Vector2(-0.5f,0f);
        enemyRB.gravityScale = 0f;
        enemyRB.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // function used to spawn an accident enemy
    public void SpawnAccident()
    {
        int randomIndex = Random.Range(enemies.Count - 3, enemies.Count);
        GameObject pref = enemies[randomIndex];

        int randomLine = Random.Range(0, 30);

        if (randomLine % 3 == 0)
        {
            spawnPoint = new Vector3(9.5f, 1.2f, 1.0f);
        }
        else if (randomLine % 3 == 2)
        {
            spawnPoint = new Vector3(9.5f, -1.1f, 1.0f);
        }
        else if (randomLine % 3 == 1)
        {
            spawnPoint = new Vector3(9.5f, -3.3f, 1.0f);
        }


        GameObject newEnemy = Instantiate(pref, spawnPoint, Quaternion.identity);

        Rigidbody2D enemyRB = newEnemy.GetComponent<Rigidbody2D>();

        enemyRB.velocity = new Vector2(-0.5f, 0f);
        enemyRB.gravityScale = 0f;
        enemyRB.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // function used to spawn a lot of enemies at some point in the game
    public void SpawnALotOfEnemies()
    {
        float p1 = 9.5f;
        float p2 = 9.5f;
        float p3 = 9.5f;
        for (int i = 0; i <= nrOfEnemies; i++)
        {
            int randomIndex = Random.Range(0, enemies.Count - 3);
            GameObject pref = enemies[randomIndex];

            int randomLine = Random.Range(0, 30);

            if (randomLine % 3 == 0)
            {
                spawnPoint = new Vector3(p1, 1.2f, 1.0f);
                p1 += 1.5f;
            }
            else if (randomLine % 3 == 2)
            {
                spawnPoint = new Vector3(p2, -1.1f, 1.0f);
                p2 += 1.5f;
            }
            else if (randomLine % 3 == 1)
            {
                spawnPoint = new Vector3(p3, -3.3f, 1.0f);
                p3 += 1.5f;
            }



            GameObject newEnemy = Instantiate(pref, spawnPoint, Quaternion.identity);

            Rigidbody2D enemyRB = newEnemy.GetComponent<Rigidbody2D>();

            enemyRB.velocity = new Vector2(-0.3f, 0f);
            enemyRB.gravityScale = 0f;
            enemyRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        nrOfEnemies += 3;
    }

    // function used to activate the big boss
    public void SpawnBigBoss()
    {
        BigBoss.GetComponent<Renderer>().enabled = true;
        BigBoss.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.2f, 0f);
        BigBoss.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        BigBoss.GetComponent<Collider2D>().enabled = true;
    }
}

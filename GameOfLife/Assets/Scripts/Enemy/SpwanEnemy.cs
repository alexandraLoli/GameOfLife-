using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> enemies;
    public Transform spawnPoint;

    private int minLimit = 5;
    private int maxLimit = 7;
    private float spawnTime = 0;

    // variables for accidents
    private int minLimitAccident = 30;
    private int maxLimitAccident = 40;
    private float spawnTimeAccident = 0;

    //public GameObject camera;
    //private GameLogic script;
    void Start()
    {
        spawnTime = Random.Range(minLimit, maxLimit);
        spawnTimeAccident = Random.Range(minLimitAccident, maxLimitAccident);

        //script = camera.AddComponent<GameLogic>();

    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTime <= 0)
        {
            SpwanRandomEnemy();
            spawnTime = Random.Range(minLimit, maxLimit);
        }

        if (spawnTimeAccident <= 0)
        {
            SpawnAccident();
            spawnTimeAccident = Random.Range(minLimitAccident, maxLimitAccident);
        }
        
        spawnTime -= Time.deltaTime;
        spawnTimeAccident -= Time.deltaTime;
    }

    public void SpwanRandomEnemy()
    {
        int randomIndex = Random.Range(0, enemies.Count - 3);
        GameObject pref = enemies[randomIndex];

        int randomLine = Random.Range(0, 30);

        if (randomLine % 3 == 0)
        {
            spawnPoint.position = new Vector3(9.5f, 1.2f, 1.0f);
        } 
        else if  (randomLine % 3 == 2)
        {
            spawnPoint.position = new Vector3(9.5f, -1.1f, 1.0f);
        } 
        else if (randomLine % 3 ==  1)
        {
            spawnPoint.position = new Vector3(9.5f, -3.3f, 1.0f);
        }

        spawnPoint.transform.rotation = Quaternion.identity;
        spawnPoint.transform.localScale = Vector3.one;

        GameObject newEnemy = Instantiate(pref, spawnPoint.position, spawnPoint.rotation);
    
        Rigidbody2D enemyRB = newEnemy.GetComponent<Rigidbody2D>();

        enemyRB.velocity = new Vector2(-0.5f,0f);
        enemyRB.gravityScale = 0f;
        enemyRB.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void SpawnAccident()
    {
        int randomIndex = Random.Range(enemies.Count - 3, enemies.Count);
        GameObject pref = enemies[randomIndex];

        int randomLine = Random.Range(0, 30);

        if (randomLine % 3 == 0)
        {
            spawnPoint.position = new Vector3(9.5f, 1.2f, 1.0f);
        }
        else if (randomLine % 3 == 2)
        {
            spawnPoint.position = new Vector3(9.5f, -1.1f, 1.0f);
        }
        else if (randomLine % 3 == 1)
        {
            spawnPoint.position = new Vector3(9.5f, -3.3f, 1.0f);
        }

        spawnPoint.transform.rotation = Quaternion.identity;
        spawnPoint.transform.localScale = Vector3.one;

        GameObject newEnemy = Instantiate(pref, spawnPoint.position, spawnPoint.rotation);

        Rigidbody2D enemyRB = newEnemy.GetComponent<Rigidbody2D>();

        enemyRB.velocity = new Vector2(-0.5f, 0f);
        enemyRB.gravityScale = 0f;
        enemyRB.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}

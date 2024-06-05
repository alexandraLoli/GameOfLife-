using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class is used to describe shield's actions 
 */

public class ShieldAction : MonoBehaviour
{
    // variables for new instance
    public GameObject canvas;
    private Money script;
    public int price;
    public Transform spawnPoint;

    // variables used for drag and drop
    private bool isDragging = false;
    private Vector3 offset;
    public bool isSet = false;
    public List<GameObject> gameTable;
    private bool nothingHappens = true;

    // variables used for defending the enemy
    public float life = 5;
    private bool inCollision = false;
    private List<GameObject> enemiesWaiting = new List<GameObject>();

    // variable to memorize where is a helper on the table
    public int squareIndex = -1;

    // variable for collider
    private Collider2D colliderShield;

    // Start is called before the first frame update
    void Start()
    {
        // we need this to verify and update the TotalMoney
        script = canvas.GetComponent<Money>();

        colliderShield = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < enemiesWaiting.Count; i++)
        {
            if (enemiesWaiting[i] == null)
            {
                enemiesWaiting.Remove(enemiesWaiting[i]);
                i--;
            }
        }

        if (enemiesWaiting.Count == 0) {
            inCollision = false;
        }


        if (isSet && inCollision)
        {
            /*
             * The shield stops enemies, so when it "dies", all the enemies
             * that were waiting need to continue their motion
             */
            if (life <= 0)
            {
                
                for (int i = 0; i < enemiesWaiting.Count; i++)
                {
                    Rigidbody2D rb = enemiesWaiting[i].GetComponent<Rigidbody2D>();
                    rb.velocity = new Vector2(-1.0f, 0.0f);
                }

                enemiesWaiting.Clear();
                Destroy(gameObject);

            } else
            {
                life -= Time.deltaTime;
            }
        }

        
    }

    // Click the shield 
    private void OnMouseDown()
    {
        // if it's not on the GameTable
        if (!isSet)
        {
            // if the player has enough money
            if (script.variableToDisplay >= price)
            {
                spawnPoint.transform.position = transform.position;
                spawnPoint.transform.rotation = Quaternion.identity;

                // put another shield in it's place
                Instantiate(this.gameObject, spawnPoint.transform.position, spawnPoint.transform.rotation);

                // useful for Drag and Drop
                isDragging = true;
                offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

                script.variableToDisplay -= price;
                nothingHappens = false;
                colliderShield.enabled = false;
            }
            // not important - used to fix a bug
            else
            {
                Instantiate(this.gameObject, spawnPoint.transform.position, spawnPoint.transform.rotation);
                nothingHappens = true;
            }
        }

        // the shield is already on the GameTable, the player wants to erase it
        else if (squareIndex != -1)
        {
            SqaureDrop square = gameTable[squareIndex].GetComponent<SqaureDrop>();
            square.inUse = false;
            Destroy(gameObject);
        }

        
    }

    // Release the mouse
    private void OnMouseUp()
    {
        // check if the release happened on the GameTable
        for (int i = 0; i < gameTable.Count && isDragging; i++)
        {
            // if yes, set the shield on the square
            if (transform.position.x > (gameTable[i].transform.position.x - 1.5)
                && transform.position.x < (gameTable[i].transform.position.x + 1.5)
                && transform.position.y > (gameTable[i].transform.position.y - 1.5)
                && transform.position.y < (gameTable[i].transform.position.y + 1.5)
                )
            {
                transform.position = gameTable[i].transform.position;
                squareIndex = i;

                SqaureDrop square = gameTable[i].GetComponent<SqaureDrop>();
                square.inUse = true;

                isDragging = false;
                isSet = true;
                colliderShield.enabled = true;
            }
        }

        // not important - used to solve bugs
        if (squareIndex == -1 && !nothingHappens)
        {
            script.variableToDisplay += price;
            Destroy(gameObject);

        }
        else if (squareIndex == -1 && nothingHappens)
        {
            Destroy(gameObject);
        }

        

    }

    // the Drag part from Drag-and-Drop
    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }

    // Collisions with the enemies
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isSet)
        {
            if (collision.gameObject.CompareTag("VirusEnemy") ||
            collision.gameObject.CompareTag("BrokenBoneEnemy") ||
            collision.gameObject.CompareTag("SweetsEnemy") ||
            collision.gameObject.CompareTag("AlcoholEnemy") ||
            collision.gameObject.CompareTag("PhoneEnemy") ||
            collision.gameObject.CompareTag("CigaretteEnemy") ||
            collision.gameObject.CompareTag("CarEnemy") ||
            collision.gameObject.CompareTag("HouseOnFireEnemy") ||
            collision.gameObject.CompareTag("SadEnemy") ||
            collision.gameObject.CompareTag("BrokenHeartEnemy") ||
            collision.gameObject.CompareTag("WeatherEnemy"))
            {
                inCollision = true;
                enemiesWaiting.Add(collision.gameObject);

            }
        }
    }
}

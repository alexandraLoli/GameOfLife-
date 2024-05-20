using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private int squareIndex = -1;

    // variable for collider
    private Collider2D colliderShield;

    // Start is called before the first frame update
    void Start()
    {
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

    private void OnMouseDown()
    {
        if (!isSet)
        {
            if (script.variableToDisplay >= price)
            {
                spawnPoint.transform.position = transform.position;
                spawnPoint.transform.rotation = Quaternion.identity;

                Instantiate(this.gameObject, spawnPoint.transform.position, spawnPoint.transform.rotation);

                isDragging = true;
                offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

                script.variableToDisplay -= price;
                nothingHappens = false;
                colliderShield.enabled = false;
            }
            else
            {
                Instantiate(this.gameObject, spawnPoint.transform.position, spawnPoint.transform.rotation);
                nothingHappens = true;
            }
        }
        else if (squareIndex != -1)
        {
            SqaureDrop square = gameTable[squareIndex].GetComponent<SqaureDrop>();
            square.inUse = false;
            Destroy(gameObject);
        }

        
    }

    private void OnMouseUp()
    {
        
        for (int i = 0; i < gameTable.Count && isDragging; i++)
        {

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

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isSet)
        {
            if (collision.gameObject.CompareTag("Illness") ||
                collision.gameObject.CompareTag("Sorrow") ||
                collision.gameObject.CompareTag("Accident") ||
                collision.gameObject.CompareTag("Addiction"))
            {
                inCollision = true;
                enemiesWaiting.Add(collision.gameObject);

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class describes the behavior of the MoneyTree
 */
public class TreeAction : MonoBehaviour
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

    //variables for showing money 
    private float moneyInterval = 5;
    public GameObject moneySign;

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
        // if the MoneyTree is set on the GameTable, is active and can send money
        if (isSet)
        {
            if (moneyInterval <= 0)
            {
                SendMoney();
                moneyInterval = 30;
            }

            moneyInterval -= Time.deltaTime;
        }
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

    // Click the MoneyTree
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

                // put another tree in it's place
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

        // the MoneyTree is already on the GameTable, the player wants to erase it
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
            // if yes, set the MoneyTree on the square
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

}

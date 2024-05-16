using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //variables for showing money 
    private float moneyInterval = 5;
    public GameObject moneySign;

    // Start is called before the first frame update
    void Start()
    {
        script = canvas.GetComponent<Money>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSet)
        {
            if (moneyInterval <= 0)
            {
                SendMoney();
                moneyInterval = 20;
            }

            moneyInterval -= Time.deltaTime;
        }
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
            }
        }

    }

    private void OnMouseUp()
    {
        Debug.Log(gameTable.Count);
        for (int i = 0; i < gameTable.Count; i++)
        {

            if (transform.position.x > (gameTable[i].transform.position.x - 1.5)
                && transform.position.x < (gameTable[i].transform.position.x + 1.5)
                && transform.position.y > (gameTable[i].transform.position.y - 1.5)
                && transform.position.y < (gameTable[i].transform.position.y + 1.5)
                )
            {
                transform.position = gameTable[i].transform.position;
            }
            isDragging = false;
            isSet = true;
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

}

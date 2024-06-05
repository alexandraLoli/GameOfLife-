using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


/*
 * This class describes helper's actions
 */

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    // variables for new instance
    public GameObject canvas;
    private Money script;
    public int price;
    public Transform spawnPoint;

    //variable for projectile
    public GameObject projectile;
    public Transform firePoint;
    private float fireTimer = 1f;

    // variable for drag and drop
    private bool isDragging = false;
    private Vector3 offset;
    public bool isSet = false;
    public List<GameObject> gameTable;
    private bool nothingHappens = true;

    // variable to memorize where is a helper on the table
    public int squareIndex = -1;

    // variable for collider
    private Collider2D colliderShield;

    private AudioManager audioManager;

    void Start()
    {
        script = canvas.GetComponent<Money>();

        // dont show the helper
        this.gameObject.GetComponent<Renderer>().enabled = false;

        colliderShield = gameObject.GetComponent<Collider2D>();

        audioManager = FindObjectOfType<AudioManager>();
    }

            
    // Update is called once per frame
    void Update()
    {
        // fire projectile just if the helper is set on the game table
        if (isSet)
        {
            if (fireTimer >= 2f)
            {
                FireProjectile();
                fireTimer = 0f;
            }

            fireTimer += Time.deltaTime;
        }
    }

    // Click the helper
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

                // put another helper in it's place
                Instantiate(this.gameObject, spawnPoint.transform.position, spawnPoint.transform.rotation);

                // useful for Drag and Drop
                isDragging = true;
                offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                this.gameObject.GetComponent<Renderer>().enabled = true;

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
        
        // the helper is already on the GameTable, the player wants to erase it
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
        for (int i = 0; i< gameTable.Count && isDragging; i++)
        {
            // if yes, set the helper on the square
            if (transform.position.x > (gameTable[i].transform.position.x - 1.5)
                && transform.position.x < (gameTable[i].transform.position.x + 1.5)
                && transform.position.y > (gameTable[i].transform.position.y - 1.5)
                && transform.position.y < (gameTable[i].transform.position.y + 1.5)
                )
            {
                SqaureDrop square = gameTable[i].GetComponent<SqaureDrop>();
                if (square.inUse)
                {
                    break;
                }
                transform.position = gameTable[i].transform.position;
                squareIndex = i;
               
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
            
        } else if (squareIndex == -1 && nothingHappens)
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

    // Method used to fire a projectile
    void FireProjectile()
    {
        if (projectile != null)
        {
            PlayFirinfSound();

            GameObject newProjectile = Instantiate(projectile, firePoint.position + new Vector3(1.0f, 0.0f, 0.0f), firePoint.rotation);
            Rigidbody2D projectileRB = newProjectile.GetComponent<Rigidbody2D>();

            projectileRB.velocity = new Vector2(1.5f, 0f);
            projectileRB.gravityScale = 0f;
            projectileRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void PlayFirinfSound()
    {
        if (audioManager != null)
        {
            FindObjectOfType<AudioManager>().PlayFireSound();
        }
    }
}

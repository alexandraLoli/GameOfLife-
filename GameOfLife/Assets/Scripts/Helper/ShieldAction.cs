using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAction : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    public bool isSet = false;
    public GameObject projectile;
    public Transform firePoint;
    private float fireTimer = 0f;

    public List<GameObject> gameTable;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {

        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isSet)
        {
            if (collision.gameObject.CompareTag("Illness") ||
                collision.gameObject.CompareTag("Sorrow") ||
                collision.gameObject.CompareTag("Accident") ||
                collision.gameObject.CompareTag("Addiction"))
            {

            }
        }
    }
}

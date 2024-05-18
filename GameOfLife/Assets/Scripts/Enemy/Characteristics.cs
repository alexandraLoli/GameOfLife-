using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characteristics : MonoBehaviour
{
    // Start is called before the first frame update

    private float despawnDistance = 16.0f;
    private float spawnPositionX;

    public int life = 3;
    void Start()
    {
        spawnPositionX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceTraveled = Mathf.Abs(transform.position.x - spawnPositionX);

        if (distanceTraveled > despawnDistance)
        {
            Destroy(gameObject);
        }

        if (life == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Helper"))
        {
            Destroy(collision.gameObject);
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-1.0f, 0.0f);
        } 
        else if (collision.gameObject.tag == gameObject.tag)
        {
            Destroy(collision.gameObject);
            life--;
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-1.0f, 0.0f);
        }
        else if (collision.gameObject.CompareTag("Avatar"))
        {
            Destroy(gameObject);
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-1.0f, 0.0f);
        }
        else if (collision.gameObject.CompareTag("AngelShield") && gameObject.CompareTag("Accident"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("AngelShield") && !gameObject.CompareTag("Accident"))
        {

            AngelScoutBehavior script = collision.gameObject.GetComponent<AngelScoutBehavior>();
            Destroy(script.angel);
            Destroy(collision.gameObject);
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-1.0f, 0.0f);
        }
        else if (collision.gameObject.CompareTag("Shield"))
        {

        }
        else
        {
            Destroy(collision.gameObject);
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-1.0f, 0.0f);
        }
    }

}

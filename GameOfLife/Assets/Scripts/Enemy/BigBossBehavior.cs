using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 * This class describes the BigBoss's actions and collisions with other gameObjects
 */

public class BigBossBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private float despawnDistance = 16.0f;
    private float spawnPositionX;

    public float life = 20;
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
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

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    // enemy is in collision with another gameObject
    private void OnCollisionEnter2D(Collision2D collision)
    {

        // enemy hits the helper and the healper dissapperat from the GameTable
        if (collision.gameObject.CompareTag("TherapistHelper") ||
            collision.gameObject.CompareTag("DoctorHelper") ||
            collision.gameObject.CompareTag("FriendHelper") ||
            collision.gameObject.CompareTag("MoneyTree") ||
            collision.gameObject.CompareTag("Shield"))
        {
            if (!collision.gameObject.CompareTag("MoneyTree") || !collision.gameObject.CompareTag("Shield"))
            {
                collision.gameObject.GetComponent<NewBehaviourScript>()
                    .gameTable[collision.gameObject.GetComponent<NewBehaviourScript>()
                    .squareIndex].GetComponent<SqaureDrop>()
                    .inUse = false;
            }
            else if(collision.gameObject.CompareTag("MoneyTree"))
            {
                collision.gameObject.GetComponent<TreeAction>()
                    .gameTable[collision.gameObject.GetComponent<TreeAction>()
                    .squareIndex].GetComponent<SqaureDrop>()
                    .inUse = false;
            }
            else if (collision.gameObject.CompareTag("Shield"))
            {
                collision.gameObject.GetComponent<ShieldAction>()
                    .gameTable[collision.gameObject.GetComponent<ShieldAction>()
                    .squareIndex].GetComponent<SqaureDrop>()
                    .inUse = false;
            }
            Destroy(collision.gameObject);
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-0.5f, 0.0f);

        }

        // big boss hit by pill
        else if (collision.gameObject.CompareTag("Illness"))
        {
            Destroy(collision.gameObject);
            life -= 0.5f;
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-0.5f, 0.0f);
        }

        // big boss hit by heart
        else if (collision.gameObject.CompareTag("Sorrow"))
        {
            Destroy(collision.gameObject);
            life -= 1;
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-0.2f, 0.0f);
        }

        // big boss hit by ying yang
        else if (collision.gameObject.CompareTag("Addiction"))
        {
            Destroy(collision.gameObject);
            life -= 0.7f;
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-0.2f, 0.0f);
        }

        // the enemy hits the avatar
        else if (collision.gameObject.CompareTag("Avatar"))
        {
            Destroy(gameObject);
        }

        // any other collision
        else
        {
            Destroy(collision.gameObject);
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-0.2f, 0.0f);
        }
    }
}

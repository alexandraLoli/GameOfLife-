using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class describes a enemy's actions and collisions with other gameObjects
 */
public class Characteristics : MonoBehaviour
{
    // Start is called before the first frame update

    private float despawnDistance = 16.0f;
    private float spawnPositionX;

    public float life = 3;
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
            collision.gameObject.CompareTag("MoneyTree"))
        {
            Debug.Log("coliziuneeee");
            if (!collision.gameObject.CompareTag("MoneyTree"))
            {
                collision.gameObject.GetComponent<NewBehaviourScript>()
                    .gameTable[collision.gameObject.GetComponent<NewBehaviourScript>()
                    .squareIndex].GetComponent<SqaureDrop>()
                    .inUse = false;
            } else
            {
                collision.gameObject.GetComponent<TreeAction>()
                    .gameTable[collision.gameObject.GetComponent<TreeAction>()
                    .squareIndex].GetComponent<SqaureDrop>()
                    .inUse = false;
            }
            Destroy(collision.gameObject);
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-0.5f, 0.0f);
            
        } 

        // the enemy is hit by it's corresponding projectile
        else if ( (collision.gameObject.CompareTag("Illness") && (gameObject.CompareTag("VirusEnemy") 
                                                                    || gameObject.CompareTag("BrokenBoneEnemy"))) ||
                  (collision.gameObject.CompareTag("Addiction") && (gameObject.CompareTag("SweetsEnemy") 
                                                                        || gameObject.CompareTag("AlcoholEnemy") 
                                                                        || gameObject.CompareTag("PhoneEnemy")
                                                                        || gameObject.CompareTag("CigaretteEnemy"))) ||
                  (collision.gameObject.CompareTag("Sorrow") && (gameObject.CompareTag("SadEnemy") 
                                                                        || gameObject.CompareTag("BrokenHeartEnemy")))
                 )
        {
            Destroy(collision.gameObject);
            life--;
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-0.5f, 0.0f);
        }

        // the enemy is another projectile than it's own
        else if ( (collision.gameObject.CompareTag("Illness") && (gameObject.CompareTag("AlcoholEnemy") || 
                                                                  gameObject.CompareTag("CigaretteEnemy") || 
                                                                  gameObject.CompareTag("SadEnemy"))) ||
                  (collision.gameObject.CompareTag("Addiction")  && (gameObject.CompareTag("SadEnemy") ||
                                                                     gameObject.CompareTag("BrokenHeartEnemy")))||
                  (collision.gameObject.CompareTag("Sorrow") && (gameObject.CompareTag("AlcoholEnemy") ||
                                                                  gameObject.CompareTag("CigaretteEnemy") ||
                                                                  gameObject.CompareTag("BrokenBoneEnemy"))) )
        {
            Destroy(collision.gameObject);
            life -= 0.5f;
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-0.5f, 0.0f);
        }

        // the enemy hits the avatar
        else if (collision.gameObject.CompareTag("Avatar"))
        {
            Destroy(gameObject);
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-0.5f, 0.0f);
        }

        // the AccidentEnemy type is in collision with the AngelShield
        else if (collision.gameObject.CompareTag("AngelShield") && (gameObject.CompareTag("CarEnemy") || 
                                                                    gameObject.CompareTag("HouseOnFireEnemy") ||
                                                                    gameObject.CompareTag("WeatherEnemy"))
                )
        {
            Destroy(gameObject);
        }

        // any enemy except the accident types are in collision with the AngelShield
        else if (collision.gameObject.CompareTag("AngelShield") && !(gameObject.CompareTag("CarEnemy") ||
                                                                    gameObject.CompareTag("HouseOnFireEnemy") ||
                                                                    gameObject.CompareTag("WeatherEnemy"))
                )
        {

            AngelScoutBehavior script = collision.gameObject.GetComponent<AngelScoutBehavior>();
            Destroy(script.angel);
            Destroy(collision.gameObject);
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-0.5f, 0.0f);
        }

        // the enemy is in collision with the shield
        else if (collision.gameObject.CompareTag("Shield"))
        {

        }

        // any other collision
        else
        {
            Destroy(collision.gameObject);
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-0.5f, 0.0f);
        }
    }

}

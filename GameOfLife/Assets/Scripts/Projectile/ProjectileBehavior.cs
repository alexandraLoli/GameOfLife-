using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private float despawnDistance = 14.5f;
    private float spawnPositionX;
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Helper"))
        {
            Rigidbody2D projectileRB = gameObject.GetComponent<Rigidbody2D>();
            projectileRB.velocity = new Vector2(1f, 0f);
        }
    }
}

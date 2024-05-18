using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelScoutBehavior : MonoBehaviour
{
    private float life = 10;
    public bool original = true;
    public GameObject angel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!original)
        {
            if (life <= 0)
            {
                Destroy(gameObject);
                Destroy(angel);
            }

            life -= Time.deltaTime;
        }
    }

}

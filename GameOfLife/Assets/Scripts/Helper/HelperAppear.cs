using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperAppear : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject helper;
    public int price;
    public GameObject canvas;
    private Money script;

    // Start is called before the first frame update
    void Start()
    {
        script = canvas.GetComponent<Money>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (script.variableToDisplay >= price)
        {
            spawnPoint.transform.position = transform.position;
            spawnPoint.transform.rotation = Quaternion.identity;

            Instantiate(helper, spawnPoint.transform.position, spawnPoint.transform.rotation);

            script.variableToDisplay -= price;
        }
    }
}

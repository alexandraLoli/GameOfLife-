using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperAppear : MonoBehaviour
{
    // variables for buying
    public int price;
    public GameObject canvas;
    private Money script;

    // variables for scout
    public GameObject angel;
    public GameObject scout;
    private AngelScoutBehavior script1;

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

            GameObject angelCopy = Instantiate(angel, new Vector3(-6, -4, 0), Quaternion.identity);
            GameObject scoutCopy = Instantiate(scout, new Vector3(-5.5f, -1, 0), Quaternion.identity);

            script1 = scoutCopy.GetComponent<AngelScoutBehavior>();
            script1.original = false;
            script1.angel = angelCopy;

            script.variableToDisplay -= price;
        }
    }
}

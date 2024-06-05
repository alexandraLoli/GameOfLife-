using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class describes the behavior of the Dollar Sign
 */
public class MoneyBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    // variables to gain money
    public GameObject canvas;
    private Money sprite;
    public int value;
    //private bool touch = false;
    void Start()
    {

        sprite = canvas.GetComponent<Money>();

        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("MoneyLayer"), LayerMask.NameToLayer("Default"), true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // When the player click on the DollarSign, they receive the money and the gameObject disspears
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            sprite.variableToDisplay += value;
            Destroy(gameObject);
        }
    }

}

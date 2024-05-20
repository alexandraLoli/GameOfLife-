using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //if (Input.GetMouseButtonDown(1)) {
        //    touch = true;
        //    OnMouseDown();
        //}

    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            sprite.variableToDisplay += value;
            Destroy(gameObject);
        }
    }

    //private void OnMouseDown()
    //{
    //    if (true)
    //    {
    //        sprite.variableToDisplay += value;
    //        Destroy(gameObject);

    //    }
    //}
}

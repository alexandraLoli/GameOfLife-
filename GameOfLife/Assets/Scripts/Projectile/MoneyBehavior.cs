using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    // variables to gain money
    public GameObject canvas;
    private Money sprite;
    void Start()
    {
        sprite = canvas.GetComponent<Money>();
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("MoneyLayer"), LayerMask.NameToLayer("Default"), true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        sprite.variableToDisplay += 50;
        Destroy(gameObject);
    }
}

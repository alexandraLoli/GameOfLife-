using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{

    // Start is called before the first frame update
    public TMP_Text textfield;
    public int minRange;
    public int maxRange;
    public int variableToDisplay;

    void Start()
    {
        
    }

    public void calculateMoney()
    {
        variableToDisplay = Random.Range(minRange, maxRange);
    }

    // Update is called once per frame
    void Update()
    {
        textfield.text = "Total: " + variableToDisplay + "$";
    }
}

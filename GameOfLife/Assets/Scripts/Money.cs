using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/*
 * 
 * This class is used to show the amount of total money that the player has.
 * 
 */
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

    // at the beginning of the game, the amount of money is random, and the range is specific to the phase of life
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

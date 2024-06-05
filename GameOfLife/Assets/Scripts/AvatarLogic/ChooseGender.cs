using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This classed is attached to the Buttons from "Choose Your Character" Stage
 *      if you click on the first button - the method ChooseBoy is called
 *      if you click on the second button - the method ChooseGirl is called
 */
public class ChooseGender : MonoBehaviour
{
    // Start is called before the first frame update

    public void ChooseGirl()
    {
        PlayerGender.Gender = "Girl";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ChooseBoy()
    {
        PlayerGender.Gender = "Boy";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}

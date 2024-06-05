using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
 * 
 *  This class is used to describe how the Avatar interacts with the enemies
 * and to check the life of the avatar and change scenes to the corresponding ending.
 * 
 */
public class AvatarLogic : MonoBehaviour
{
    // list with all lifebar gameObjects
    public List<GameObject> lifes;

    // list with all avatar's states
    public List<Renderer> avatarGirl;
    public List<Renderer> avatarBoy;

    // variables related to avatar's life
    // life as how much life now
    private int life;

    // fullLife to calculate the state the avatar is in
    private int fullLife;

    // which phase is now?
    public int stage;


    // Start is called before the first frame update
    void Start()
    {
        // in the beginning, life is full
        life = lifes.Count;
        fullLife = lifes.Count;

        // not good to render all sprites
        for (int i = 0; i < avatarGirl.Count; i++)
        {
            avatarGirl[i].enabled = false;
        }

        for (int i = 0;i < avatarBoy.Count; i++)
        {
            avatarBoy[i].enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerGender.Gender.Equals("Boy"))
        {
            // avatar is happy in the first trinity
            if (life > fullLife / 3 * 2)
            {
                avatarBoy[2].enabled = true;
            }

            // avatar is neutral in the second trinity
            else if (life > fullLife / 3 * 1)
            {
                avatarBoy[2].enabled = false;
                avatarBoy[1].enabled = true;
            }

            // avatar is sad in the third trinity
            else if (life > 0)
            {
                avatarBoy[1].enabled = false;
                avatarBoy[0].enabled = true;
            }

            // the child died
            if (life <= 0 && stage == 0)
            {
                SceneManager.LoadScene(16);
            }

            // the teen died
            else if (life <= 0 && stage == 1)
            {
                SceneManager.LoadScene(17);
            }

            // the adult died
            else if (life <= 0 && stage == 2)
            {
                SceneManager.LoadScene(18);
            }

            // the old one died
            else if (life <= 0 && stage == 3)
            {
                SceneManager.LoadScene(14);
            }
        }
        
        else if (PlayerGender.Gender.Equals("Girl"))
        {
            // avatar is happy in the first trinity
            if (life > fullLife / 3 * 2)
            {
                avatarGirl[2].enabled = true;
            }

            // avatar is neutral in the second trinity
            else if (life > fullLife / 3 * 1)
            {
                avatarGirl[2].enabled = false;
                avatarGirl[1].enabled = true;
            }

            // avatar is sad in the third trinity
            else if (life > 0)
            {
                avatarGirl[1].enabled = false;
                avatarGirl[0].enabled = true;
            }

            // the child died
            if (life <= 0 && stage == 0)
            {
                SceneManager.LoadScene(16);
            } 
            
            // the teen died
            else if (life <= 0 && stage == 1)
            {
                SceneManager.LoadScene(17);
            }
            
            // the adult died
            else if (life <= 0 && stage == 2)
            {
                SceneManager.LoadScene(18);
            } 
            
            // the old one died
            else if (life <= 0 && stage == 3)
            {
                SceneManager.LoadScene(14);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // the avatar is hit by any regular  enemy
        if (collision.gameObject.CompareTag("VirusEnemy") ||
            collision.gameObject.CompareTag("BrokenBoneEnemy") ||
            collision.gameObject.CompareTag("SweetsEnemy") ||
            collision.gameObject.CompareTag("AlcoholEnemy") ||
            collision.gameObject.CompareTag("PhoneEnemy") ||
            collision.gameObject.CompareTag("CigaretteEnemy") ||
            collision.gameObject.CompareTag("CarEnemy") ||
            collision.gameObject.CompareTag("HouseOnFireEnemy") ||
            collision.gameObject.CompareTag("SadEnemy") ||
            collision.gameObject.CompareTag("BrokenHeartEnemy") ||
            collision.gameObject.CompareTag("WeatherEnemy"))
        {
            life--;
            Destroy(lifes[lifes.Count - 1]);
            lifes.RemoveAt(lifes.Count - 1);    
        }

        // the avatar is hit by the big boss
        else if (collision.gameObject.CompareTag("BigBossEnemy"))
        {
            life -= 5;
            for (int i = 1; i <= 5; i++)
            {
                Destroy(lifes[lifes.Count - 1]);
                lifes.RemoveAt(lifes.Count - 1);
            }
        }
    }
}

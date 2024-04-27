using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvatarLogic : MonoBehaviour
{
    public List<GameObject> lifes;
    public List<Renderer> avatarGirl;
    public List<Renderer> avatarBoy;
    private int life;
    private int fullLife;


    // Start is called before the first frame update
    void Start()
    {
        life = lifes.Count;
        fullLife = lifes.Count;
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
        if (life > fullLife / 3 * 2)
        {
            avatarBoy[2].enabled = true;
        }
        else if (life > fullLife / 3 * 1)
        {
            avatarBoy[2].enabled = false;
            avatarBoy[1].enabled = true;
        }
        else if (life > 0)
        {
            avatarBoy[1].enabled = false;
            avatarBoy[0].enabled = true;
        }
        if (life == 0)
        {
            SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Illness") ||
            collision.gameObject.CompareTag("Sorrow") ||
            collision.gameObject.CompareTag("Accident") ||
            collision.gameObject.CompareTag("Addiction"))
        {
            life--;
            Destroy(lifes[lifes.Count - 1]);
            lifes.RemoveAt(lifes.Count - 1);    
        }
    }
}

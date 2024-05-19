using UnityEngine;

public class Sounds : MonoBehaviour
{
    public  AudioSource audioSource;

    private void Start()
    {
        audioSource.Play();
    }

    public void PlaySound()
    {
        audioSource.Play();
    }
}

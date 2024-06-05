using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    public AudioClip clickSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clickSound;
        audioSource.playOnAwake = false;
    }

    public void PlayClickSound()
    {
        audioSource.Play();
    }
}

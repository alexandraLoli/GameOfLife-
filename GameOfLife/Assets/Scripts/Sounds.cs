using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource;
    public AudioSource backgroundMusicSource;
    public AudioSource effectsSource;
    public AudioClip clickSound;
    public AudioClip hitSound;
    public AudioClip avatarHit;
    public AudioClip helperHit;
    public AudioClip fire;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            if (backgroundMusicSource == null)
            {
                backgroundMusicSource = gameObject.AddComponent<AudioSource>();
            }

            if (effectsSource == null)
            {
                effectsSource = gameObject.AddComponent<AudioSource>();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        if (backgroundMusicSource.clip != null && !backgroundMusicSource.isPlaying)
        {
            backgroundMusicSource.Play();
        }
    }

    public void PlayClickSound()
    {
        if (clickSound != null)
        {
            effectsSource.PlayOneShot(clickSound);
        }
    }

    public void PlayHitSound()
    {
        if (hitSound != null)
        {
            effectsSource.PlayOneShot(hitSound);
        }
    }

    public void PlayAvatarHitSound()
    {
        if (avatarHit != null)
        {
            effectsSource.PlayOneShot(avatarHit);
        }
    }

    public void PlayHelperHitSound()
    {
        if (helperHit != null)
        {
            effectsSource.PlayOneShot(helperHit);
        }
    }

    public void PlayFireSound()
    {
        if (fire != null)
        {
            effectsSource.PlayOneShot(fire);
        }
    }

    public static void StopMusic()
    {
        if (instance != null && instance.backgroundMusicSource.isPlaying)
        {
            instance.backgroundMusicSource.Stop();
            Destroy(instance.gameObject);
            instance = null;
        }
    }
}

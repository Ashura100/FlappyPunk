using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioMixer audioMixer;
    public AudioSource musicPlayer;
    public AudioSource sfxPlayer;

    [SerializeField]
    private AudioClip themeSound, gameSound, carSound;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public void PlayTheme()
    {
        musicPlayer.clip = themeSound;
        musicPlayer.Play();
    }

    public void PlayGameSound()
    {
        musicPlayer.clip = gameSound;
        musicPlayer.Play();
    }
    // Arrête la musique en cours
    public void StopCurrentSound()
    {
        musicPlayer.Stop();
        sfxPlayer.Stop();
    }
}
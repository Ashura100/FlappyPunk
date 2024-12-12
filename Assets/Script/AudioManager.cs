using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioMixer audioMixer;
    public AudioSource musicGame;
    public AudioSource sfxPlayer;

    [SerializeField]
    private AudioClip carSound;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;

        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene.name);
    }

    // D�termine quelle musique jouer en fonction du nom de la sc�ne
    private void PlayMusicForScene(string sceneName)
    {
        if (sceneName == "New Scene")
        {

        }
        else
        {
            StopCurrentSound();
        }
    }

    // Arr�te la musique en cours
    public void StopCurrentSound()
    {
        musicGame.Stop();
        sfxPlayer.Stop();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
using System;
using System.Xml.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event Action<bool> IsCrashed;

    private float _currentScore;
    public bool _isCrashed;

    public float CurrentScore
    {
        get => _currentScore;
        set
        {
            _currentScore = value;
            UIManager.Instance.UpdateScore(_currentScore);
        }
    }

    public bool IsCrashedStatus
    {
        get => _isCrashed;
        set
        {
            if (_isCrashed != value)
            {
                _isCrashed = value;
                IsCrashed?.Invoke(_isCrashed); // Déclenche l'événement.
            }
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResetGame()
    {
        CurrentScore = 0;
        IsCrashedStatus = false;
    }

    public void Exit()
    {
        if (Application.isEditor)//jeu tourne dans l'editeur
        {
#if UNITY_EDITOR //Build = Directive de compilation(transformation langage de haut niveau en langage machine)  = si editor =/ compilation ignoré
            UnityEditor.EditorApplication.isPlaying = false;
#endif


        }
        else
        {
            Application.Quit();
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public event Action<bool> OnGameCrashed;

    private float _currentScore;
    private bool _isCrashed;

    // Gestion du score
    public float CurrentScore
    {
        get => _currentScore;
        set
        {
            _currentScore = value;
            UIManager.Instance.UpdateScore(_currentScore);
        }
    }

    // Gestion du statut "Crashed"
    public bool IsCrashedStatus
    {
        get => _isCrashed;
        set
        {
            if (_isCrashed != value)
            {
                _isCrashed = value;
                OnGameCrashed?.Invoke(_isCrashed); // D�clenche l'�v�nement
            }
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        PauseGame(); // D�marre avec le jeu en pause
    }

    // M�thode pour commencer le jeu
    public void StartGame()
    {
        Time.timeScale = 1;
    }

    // M�thode pour mettre le jeu en pause
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    // M�thode pour rejouer la partie proprement (recharge la sc�ne active)
    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // M�thode pour quitter proprement
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

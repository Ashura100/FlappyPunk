using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event Action<bool> IsCrashed;

    private float _currentScore;
    private bool _isCrashed;

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

    public void ResetGame()
    {
        CurrentScore = 0;
        IsCrashedStatus = false;
    }

}

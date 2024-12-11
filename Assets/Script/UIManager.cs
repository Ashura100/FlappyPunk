using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField]
    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI messageDisplay;

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

    private void OnEnable()
    {
        GameManager.Instance.IsCrashed += OnGameOver;
    }

    private void OnDisable()
    {
        GameManager.Instance.IsCrashed -= OnGameOver;
    }

    private void OnGameOver(bool status)
    {
        messageDisplay.text = status ? "Game Over!" : "";
    }

    public void UpdateScore(float score)
    {
        scoreDisplay.text = "Score: " + score.ToString("0");
    }
}

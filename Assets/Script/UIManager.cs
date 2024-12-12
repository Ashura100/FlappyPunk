using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField]
    public TextMeshProUGUI scoreDisplay, messageDisplay;

    // TMP_Dropdown pour la qualité visuelle
    [SerializeField] public TMP_Dropdown qualityDrop;
    // Slider pour le volume principal et le volume des SFX
    [SerializeField] public Slider musicSlider;
    [SerializeField] public Slider sfxSlider;

    // Toggle et label pour le plein écran
    [SerializeField] public Toggle fullScreenToggle;

    [SerializeField] GameObject start, option;

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

    public void StartButton()
    {
        start.SetActive(false);
        GameManager.Instance.StartGame();
    }

    public void PauseButton()
    {
        option.SetActive(true);
        GameManager.Instance.PauseGame();
    }

    public void OptionButton()
    {
        start.SetActive(false);
        option.SetActive(true);
    }

    public void ExitOption()
    {
        start.SetActive(true);
        option.SetActive(false);
    }

    public void ExitButton()
    {
        GameManager.Instance.Exit();
    }
}

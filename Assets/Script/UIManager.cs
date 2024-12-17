using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI scoreDisplay;
    [SerializeField] private TextMeshProUGUI messageDisplay;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject gameMenu;
    [SerializeField] private GameObject optionMenu;
    [SerializeField] private GameObject menuButton;
    [SerializeField] private GameObject replayButton;

    // TMP_Dropdown pour la qualité visuelle
    [SerializeField] public TMP_Dropdown qualityDrop;
    // Slider pour le volume principal et le volume des SFX
    [SerializeField] public Slider musicSlider;
    [SerializeField] public Slider sfxSlider;
    // Toggle et label pour le plein écran
    [SerializeField] public Toggle fullScreenToggle;

    bool wasInGame = false;

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
        AudioManager.Instance.PlayTheme(); // Joue la musique principale
    }

    private void OnEnable()
    {
        GameManager.Instance.OnGameCrashed += OnGameOver;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameCrashed -= OnGameOver;
    }

    // Méthode appelée lorsque le joueur perd
    private void OnGameOver(bool isCrashed)
    {
        if (isCrashed)
        {
            messageDisplay.text = "Game Over!";
            menuButton.SetActive(true);
            replayButton.SetActive(true);
            GameManager.Instance.PauseGame();
        }
        else
        {
            messageDisplay.text = "";
        }
    }

    // Met à jour l'affichage du score
    public void UpdateScore(float score)
    {
        scoreDisplay.text = $"Score: {score:0}";
    }

    // Bouton pour démarrer la partie
    public void StartButton()
    {
        startMenu.SetActive(false);
        gameMenu.SetActive(true);
        GameManager.Instance.StartGame();
    }

    // Bouton pour rejouer la partie
    public void ReplayButton()
    {
        GameManager.Instance.ReplayGame();
    }

    // Bouton pour ouvrir le menu pause/options
    public void PauseButton()
    {
        optionMenu.SetActive(true);
        wasInGame = true;
        GameManager.Instance.PauseGame();
    }

    public void OptionButton()
    {
        startMenu.SetActive(false);
        optionMenu.SetActive(true);
    }

    public void ExitOptionButton()
    {
        optionMenu.SetActive(false);

        // Retournez à l'état approprié en fonction de wasInGame
        if (wasInGame)
        {
            GameManager.Instance.StartGame(); // Reprendre le jeu
        }
        else
        {
            startMenu.SetActive(true); // Retourner au menu principal
        }
    }

    public void ExitButton()
    {
        GameManager.Instance.Exit();
    }
}

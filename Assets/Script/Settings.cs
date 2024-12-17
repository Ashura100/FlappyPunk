using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    void Start()
    {
        // Initialiser les volumes
        SetVolume(PlayerPrefs.GetFloat("MusicVolume", 0.5f));
        SetSfxVolume(PlayerPrefs.GetFloat("SfxVolume", 0.5f));

        UIManager.Instance.musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        UIManager.Instance.sfxSlider.value = PlayerPrefs.GetFloat("SfxVolume", 0.5f);

        // Initialiser la liste des niveaux de qualité
        UIManager.Instance.qualityDrop.ClearOptions();
        List<string> options = new List<string>();

        int currentQualityIndex = QualitySettings.GetQualityLevel();
        string[] qualityLevels = QualitySettings.names;

        for (int i = 0; i < qualityLevels.Length; i++)
        {
            options.Add(qualityLevels[i]);
        }

        UIManager.Instance.qualityDrop.AddOptions(options);
        UIManager.Instance.qualityDrop.value = currentQualityIndex;
        UIManager.Instance.qualityDrop.RefreshShownValue();

        // Initialiser le mode plein écran
        UIManager.Instance.fullScreenToggle.isOn = Screen.fullScreen;

        // Ajouter des listeners
        UIManager.Instance.musicSlider.onValueChanged.AddListener(delegate { SetVolume(UIManager.Instance.musicSlider.value); });
        UIManager.Instance.sfxSlider.onValueChanged.AddListener(delegate { SetSfxVolume(UIManager.Instance.sfxSlider.value); });
        UIManager.Instance.fullScreenToggle.onValueChanged.AddListener(SetPleinEcran);
        UIManager.Instance.qualityDrop.onValueChanged.AddListener(SetQuality);
    }

    // Ajuster le volume principal
    public void SetVolume(float volume)
    {
        float dB = Mathf.Log10(volume) * 20 - 20;
        AudioManager.Instance.audioMixer.SetFloat("MusicVolume", dB);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    // Ajuster le volume des SFX
    public void SetSfxVolume(float volume)
    {
        float dB = Mathf.Log10(volume) * 20;
        AudioManager.Instance.audioMixer.SetFloat("SfxVolume", dB);
        PlayerPrefs.SetFloat("SfxVolume", volume);
    }

    // Activer/désactiver le plein écran
    public void SetPleinEcran(bool isPleinEcran)
    {
        Screen.fullScreen = isPleinEcran;
    }

    // Changer la qualité visuelle
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}

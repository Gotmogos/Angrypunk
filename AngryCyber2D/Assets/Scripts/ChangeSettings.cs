using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSettings : MonoBehaviour
{
    public Slider volumeSlider;
    private AudioSource audioSource;
    private const string volumeKey = "MusicVolume";

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        volumeSlider.value = PlayerPrefs.GetFloat(volumeKey, 1f);
        audioSource.volume = volumeSlider.value;
        volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }

    private void ChangeVolume()
    {
        audioSource.volume = volumeSlider.value;
        PlayerPrefs.SetFloat(volumeKey, volumeSlider.value);
    }

    public void OnMainMenuFromSettings()
    {
        SceneManager.LoadScene(0);
    }
}

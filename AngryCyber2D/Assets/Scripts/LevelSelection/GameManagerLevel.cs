using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerLevel : MonoBehaviour
{
    public GameObject _panellevel;
    public AudioSource _audioSource;
    private void Awake()
    {
        _audioSource.volume = PlayerPrefs.GetFloat("MusicVolume");
    }
    private void OnDeloadl()
    {
        _panellevel.SetActive(false);
    }
    private void Update()
    {
        Invoke("OnDeloadl", 1f);
        _audioSource.volume = PlayerPrefs.GetFloat("MusicVolume");
    }
    public void OnManinMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void OnLevelLoad(int level)
    {
        SceneManager.LoadScene(level);
    }

}

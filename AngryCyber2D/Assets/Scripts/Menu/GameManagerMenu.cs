using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMenu : MonoBehaviour
{
     public GameObject _panel;
    
    private void OnDeload()
    {
       _panel.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
    public void Exit()
    {
        Application.Quit();
    }
    private void Update()
    {
        Invoke("OnDeload", 1f);
    }
}
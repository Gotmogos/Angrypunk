using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public int scene;
    public void OnLevelLoadThis()
    {
        Invoke("LoadSceneThis", 1f);
    }
    public void LoadSceneThis()
    {
        SceneManager.LoadScene(scene);
    }
}

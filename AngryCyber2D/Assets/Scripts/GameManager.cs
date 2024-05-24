using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _enemy;
    [SerializeField] private GameObject _pauseMenu;
    private bool _enable;
    private int _level;

    private void Awake()
    {
        _level = 1;
        _pauseMenu.SetActive(false);
        _enable = false;
        
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            _enemy = true;
        }
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            _enemy = false;
        }
       
    }
    void Update()
    {        
        if (STaticInventory.slots == 0 && _enemy == true)
        {
           Invoke( "OnLose", 0.5f);
        }
        if (STaticInventory.slots > 0 && _enemy == false)
        {
            SceneManager.LoadScene(2);
        }
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            _enemy = true;
        }
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            _enemy = false;
        }
        if  (Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseMenu.SetActive(!_enable);
            _enable = !_enable;
        }
        Debug.Log(STaticInventory.slots);
    }

    public void OnLose()
    {
        SceneManager.LoadScene(0);
    }
    public void OnmainMenuFromLevel()
    {
        SceneManager.LoadScene(0);
    }
    public void OnLevelSelection()
    {
        SceneManager.LoadScene(2);
    }
    public void Continue()
    {
        _pauseMenu.SetActive(!_enable);
        _enable = !_enable;
    }
    public void OnDisable()
    {          
            STaticInventory.slots = 0;
            Debug.Log(STaticInventory.slots);
            Debug.Log("Yes, I am alive");                          
    }
}

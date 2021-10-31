using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuButton : MonoBehaviour
{
    [SerializeField] private string firstLevelName;
    [SerializeField] private bool isLoadButton;

    private void Awake()
    {
        if (isLoadButton)
        {
            if (PlayerPrefs.HasKey("LastLevel"))
            {
                GetComponent<Button>().interactable = false;
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(firstLevelName, LoadSceneMode.Single);
    }
    
    public void LoadGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("LastLevel"), LoadSceneMode.Single);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}

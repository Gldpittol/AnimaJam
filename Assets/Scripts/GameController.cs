using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    None,
    Gameplay,
    Cutscene,
    GameOver
}

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public GameState gameState = GameState.Gameplay;
    private void Awake()
    {
        Instance = this;
    }

    public void GoToNextLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}

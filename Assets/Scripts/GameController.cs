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
    public GameObject TransitionOut;
    public GameObject TransitionIn;
    private void Awake()
    {
        Instance = this;
        Instantiate(TransitionOut, Vector2.zero, Quaternion.identity);
    }

    public void GoToNextLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
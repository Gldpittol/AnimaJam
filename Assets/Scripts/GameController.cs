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
        Destroy(AudioManager.Instance);
        AudioManager.Instance = null;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void ShakeCamera(float duration)
    {
        StartCoroutine(ShakeCameraCoroutine(duration));
    }

    public IEnumerator ShakeCameraCoroutine(float duration)
    {
        Camera.main.GetComponentInParent<Animator>().enabled = true;
        yield return new WaitForSeconds(duration);
        Camera.main.GetComponentInParent<Animator>().enabled = false;
    }
    
}

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
    public string levelName;
    public AudioClip sceneMusic;

    public static string LastScene = "";
    
    private void Awake()
    {
        Instance = this;
        Instantiate(TransitionOut, Vector2.zero, Quaternion.identity);
        if(!string.IsNullOrEmpty(levelName)) PlayerPrefs.SetString("LastLevel", levelName);
    }

    private void Start()
    {
        if (LastScene != SceneManager.GetActiveScene().name)
        {
            if(sceneMusic != null) AudioManager.Instance.PlayMusic(sceneMusic);
            LastScene = SceneManager.GetActiveScene().name;
        }
    }

    public void GoToNextLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void ShakeCamera(float duration)
    {
        StartCoroutine(ShakeCameraCoroutine(duration));
    }
    
    public void SwapLevel(string nextLevelName)
    {
        StartCoroutine(SwapLevelCoroutine(nextLevelName));
    }

    public IEnumerator SwapLevelCoroutine(string nextLevelName)
    {
        yield return new WaitForSeconds(0.2f);
        GameObject temp = Instantiate(GameController.Instance.TransitionIn, Vector3.zero, Quaternion.identity);
        yield return new WaitForSeconds(temp.GetComponent<Transition>().transitionDuration + 0.2f);
        GameController.Instance.GoToNextLevel(nextLevelName);
    }

    public IEnumerator ShakeCameraCoroutine(float duration)
    {
        Camera.main.GetComponentInParent<Animator>().enabled = true;
        yield return new WaitForSeconds(duration);
        Camera.main.GetComponentInParent<Animator>().enabled = false;
    }
    
}

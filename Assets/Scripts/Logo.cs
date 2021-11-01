using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Logo : MonoBehaviour
{
    public float delay;
    public string sceneToLoad;

    private void Awake()
    {
        StartCoroutine(LogoCoroutine());
    }

    public IEnumerator LogoCoroutine()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }
}

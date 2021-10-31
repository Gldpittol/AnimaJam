using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTrigger : MonoBehaviour
{
    public string nextLevelName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameController.Instance.gameState != GameState.Gameplay) return;
        
        if (other.CompareTag("Player"))
        {
            SwapLevel();
        }
    }
    
    public void SwapLevel()
    {
        StartCoroutine(SwapLevelCoroutine());
    }

    public IEnumerator SwapLevelCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        GameObject temp = Instantiate(GameController.Instance.TransitionIn, Vector3.zero, Quaternion.identity);
        yield return new WaitForSeconds(temp.GetComponent<Transition>().transitionDuration + 0.2f);
        GameController.Instance.GoToNextLevel(nextLevelName);
    }
}

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
            GameController.Instance.SwapLevel(nextLevelName);
        }
    }
    
   
}

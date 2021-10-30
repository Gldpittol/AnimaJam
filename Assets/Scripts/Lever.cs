using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private List<Light> associatedLightsList = new List<Light>();

    private bool isTouching = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isTouching)
        {
            if (LightsPuzzleManager.Instance.isPuzzleCompleted) return;
            
            foreach (Light light in associatedLightsList)
            {
                light.SwitchState();
            }
            
            LightsPuzzleManager.Instance.CheckIfPuzzleCompleted();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) isTouching = true;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player")) isTouching = false;
    }
}

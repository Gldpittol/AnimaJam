using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashLever : MonoBehaviour
{

    [SerializeField] private GameObject trash;
    private bool isTouching = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isTouching)
        {
            TrashPuzzle.Instance.DumpTrash();
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

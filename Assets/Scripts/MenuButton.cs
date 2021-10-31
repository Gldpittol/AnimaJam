using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private string firstLevelName;
    [SerializeField] private bool isLoadButton;
    [SerializeField] private Image myImage;

    private bool canInteract = true;

    private void Awake()
    {
        if (isLoadButton)
        {
            if (!PlayerPrefs.HasKey("LastLevel"))
            {
                GetComponent<Button>().interactable = false;
                myImage.color = new Color(1, 1, 1, 0.5f);
            }
        }
    }

    public void StartGame()
    {
        if (!canInteract) return;
        if (GameController.Instance.gameState == GameState.Cutscene) return;
        canInteract = false;
        StartCoroutine(InteractCoroutine());
        GameController.Instance.SwapLevel(firstLevelName);
    }
    
    public void LoadGame()
    {
        if (!canInteract) return;
        if (GameController.Instance.gameState == GameState.Cutscene) return;
        canInteract = false;
        StartCoroutine(InteractCoroutine());
        GameController.Instance.SwapLevel(PlayerPrefs.GetString("LastLevel"));
    }
    
    public void QuitGame()
    {
        StartCoroutine(InteractCoroutine());
        Application.Quit();
    }

    public void IncreaseSize()
    {
        if(GetComponent<Button>().interactable) transform.localScale = new Vector2(1.1f, 1.1f);
    }
    
    public void DecreaseSize()
    {
        transform.localScale = new Vector2(1f, 1f);
    }

    public IEnumerator InteractCoroutine()
    {
        myImage.color = new Color(1, 1, 1, 0.7f);
        yield return new WaitForSeconds(0.1f);
        myImage.color = new Color(1, 1, 1, 1);
    }
}

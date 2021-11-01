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
    [SerializeField] private GameObject myPanel;
    [SerializeField] private float myPanelDelay;

    private bool canInteract = true;

    [SerializeField] private bool isAudioButton;
    [SerializeField] private bool isMusicButton;
    [SerializeField] private Sprite spriteOn;
    [SerializeField] private Sprite spriteOff;

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
        
        if (isAudioButton)
        {
            if (!PlayerPrefs.HasKey("Audio"))
            {
                myImage.sprite = spriteOn;
            }
            else
            {
                if (PlayerPrefs.GetInt("Audio") == 1)
                {
                    myImage.sprite = spriteOn;
                    PlayerPrefs.SetInt("Audio", 1);
                }
                else
                {
                    myImage.sprite = spriteOff;
                }
            }
        }
        
        if (isMusicButton)
        {
            if (!PlayerPrefs.HasKey("Music"))
            {
                myImage.sprite = spriteOn;
                PlayerPrefs.SetInt("Music", 1);
            }
            else
            {
                if (PlayerPrefs.GetInt("Music") == 1)
                {
                    myImage.sprite = spriteOn;
                }
                else
                {
                    myImage.sprite = spriteOff;
                }
            }
        }
    }
    private void OnEnable()
    {
        DecreaseSize();
    }

    public void SwitchMusic()
    {
        if (PlayerPrefs.GetInt("Music") == 1)
        {
            PlayerPrefs.SetInt("Music", 0);
            myImage.sprite = spriteOff;
        }
        else
        {
            PlayerPrefs.SetInt("Music", 1);
            myImage.sprite = spriteOn;
        }
        AudioManager.Instance.UpdateMusicAndAudio();
    }
    
    public void SwitchAudio()
    {
        if (PlayerPrefs.GetInt("Audio") == 1)
        {
            PlayerPrefs.SetInt("Audio", 0);
            myImage.sprite = spriteOff;
        }
        else
        {
            PlayerPrefs.SetInt("Audio", 1);
            myImage.sprite = spriteOn;
        }
        
        AudioManager.Instance.UpdateMusicAndAudio();
    }

    public void DefaultClick()
    {
        if (GameController.Instance.gameState == GameState.Cutscene) return;
        StartCoroutine(InteractCoroutine());
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

    public void OpenPanel()
    {
        if (GameController.Instance.gameState == GameState.Cutscene) return;
        StartCoroutine(OpenPanelCoroutine());
    }
    
    public IEnumerator OpenPanelCoroutine()
    {
        myPanel.SetActive(true);
        GameController.Instance.gameState = GameState.Cutscene;
        myPanel.transform.localScale = Vector3.zero;
        while (myPanel.transform.localScale.x < 1)
        {
            float newValue =  Time.deltaTime / myPanelDelay;
            myPanel.transform.localScale += new Vector3(newValue, newValue, newValue);
            if(myPanel.transform.localScale.x > 1) myPanel.transform.localScale = Vector3.one;
            yield return null;
        }

        GameController.Instance.gameState = GameState.Gameplay;
    }
    
    public void ClosePanel()
    {
        if (GameController.Instance.gameState == GameState.Cutscene) return;
        StartCoroutine(ClosePanelCoroutine());
    }
    
    public IEnumerator ClosePanelCoroutine()
    {
        GameController.Instance.gameState = GameState.Cutscene;
        myPanel.transform.localScale = Vector3.one;
        while (myPanel.transform.localScale.x > 0)
        {
            float newValue =  Time.deltaTime / myPanelDelay;
            myPanel.transform.localScale -= new Vector3(newValue, newValue, newValue);
            if(myPanel.transform.localScale.x < 0) myPanel.transform.localScale = Vector3.zero;
            yield return null;
        }
        myPanel.SetActive(false);
        GameController.Instance.gameState = GameState.Gameplay;
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    private SpriteRenderer sr;
    private bool isOn = true;
    [SerializeField] private bool defaultOn = false;

    public bool IsOn => isOn;

    public Sprite[] sprites;
    public bool isType2;
    public int initialID;

    public int currentID;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (!isType2)
        {
            SwitchState();
            if(defaultOn) SwitchState();
        }
        else
        {
            SwitchStateType2(initialID);
        }
    }

    public void SwitchState()
    {
        isOn = !isOn;
        
        if (!isOn)
        {
            sr.color = Color.gray;
        }
        else
        {
            sr.color = Color.white;
        }
    }
    
    public void SwitchStateType2(int spriteID)
    {
        sr.sprite = sprites[spriteID];
        currentID = spriteID;
    }
    
    public void SwitchStateType2()
    {
        currentID++;
        if (currentID == 3) currentID = 0;
        sr.sprite = sprites[currentID];
    }
}

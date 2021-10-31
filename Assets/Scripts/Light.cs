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
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SwitchState();
        if(defaultOn) SwitchState();
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
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] private bool isOn = true;

    public bool IsOn => isOn;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SwitchState();
    }

    public void SwitchState()
    {
        isOn = !isOn;
        
        if (!isOn)
        {
            sr.color = Color.black;
        }
        else
        {
            sr.color = Color.red;
        }
    }
}

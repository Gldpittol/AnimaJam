using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapResizer : MonoBehaviour
{
    [SerializeField] private float scaleX, scaleY;
    private void Awake()
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(Screen.width / 10 * scaleX, Screen.width / 10 * scaleY);
    }
}

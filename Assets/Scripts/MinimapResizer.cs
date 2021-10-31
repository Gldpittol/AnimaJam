using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapResizer : MonoBehaviour
{
    [SerializeField] private float scaleX, scaleY;
    [SerializeField] private GameObject border;
    [SerializeField] private float borderExtraScaleX, borderExtraScaleY;
    [SerializeField] private float bgExtraScaleX, bgExtraScaleY;
    [SerializeField] private GameObject bgImage;
    private void Awake()
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(Screen.width / 10 * scaleX, Screen.width / 10 * scaleY);
        border.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 10 * scaleX + borderExtraScaleX, Screen.width / 10 * scaleY + borderExtraScaleY);
        bgImage.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 10 * scaleX + bgExtraScaleX, Screen.width / 10 * scaleY + bgExtraScaleY);
    }
}

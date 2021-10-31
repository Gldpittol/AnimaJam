using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenoidalMovement : MonoBehaviour
{
    public float Intensity;
    public float Speed;

    private float currentTime;
    void Update()
    {
        currentTime += Time.deltaTime;
        transform.position = transform.position + new Vector3(0.0f, Mathf.Sin(currentTime * Speed), 0.0f) * Intensity;
    }
}
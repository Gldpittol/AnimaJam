using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float defaultSpeed = 2f;
    public float fastSpeed = 15f;
    public float fasteSpeedDuration = 0.4f;

    private float currentSpeed;

    private void Awake()
    {
        currentSpeed = defaultSpeed;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + currentSpeed * Time.deltaTime * transform.localScale.x, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StopAllCoroutines();
        StartCoroutine(SwapDirection(other.gameObject));
    }

    public IEnumerator SwapDirection(GameObject other)
    {
        if (other.transform.position.x > transform.position.x) 
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }

        currentSpeed = fastSpeed;
        yield return new WaitForSeconds(fasteSpeedDuration);
        currentSpeed = defaultSpeed;
    }
}

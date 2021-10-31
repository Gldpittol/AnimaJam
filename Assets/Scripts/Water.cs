using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float speed;

    public bool moveBoth = false;
    public bool invert = true;

    private void Update()
    {
        if(!moveBoth) transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y,
            transform.position.z);
        else
        {
            if(!invert) transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y + speed * Time.deltaTime,
                transform.position.z);
            else
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y - speed * Time.deltaTime,
                    transform.position.z);
            }
        }
    }
}

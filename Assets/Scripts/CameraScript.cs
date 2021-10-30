using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Vector3 offset;

    public void Update()
    {
        transform.position = Player.Instance.transform.position + offset;
    }
}

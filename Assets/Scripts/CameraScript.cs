using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Vector3 offset;
    public static bool FollowPlayer = true;
    public void Update()
    {
        if(FollowPlayer) transform.position = Player.Instance.transform.position + offset;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    public Vector2 effectMultiplier;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * effectMultiplier.x, deltaMovement.y * effectMultiplier.y, deltaMovement.z) ;
        lastCameraPosition = cameraTransform.position;
    }
}

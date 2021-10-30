using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private void Update()
    {
        transform.localPosition = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            StopAllCoroutines();
            StartCoroutine(ResetGroundingCoroutine());
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            Player.Instance.DisableGrounding();
        }
    }

    private IEnumerator ResetGroundingCoroutine()
    {
        yield return null;
        yield return null;

        Player.Instance.ResetGrounding();
    }
}

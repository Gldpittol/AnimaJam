using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashLever : MonoBehaviour
{
    private bool isTouching = false;
    private Animator myAnimator;
    private bool canSwitch = true;
    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isTouching && canSwitch)
        {
            StartCoroutine(FlipSwitchCoroutine());
            TrashPuzzle.Instance.DumpTrash();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) isTouching = true;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player")) isTouching = false;
    }
    
    public IEnumerator FlipSwitchCoroutine()
    {
        canSwitch = false;
        myAnimator.Play("LeverAnimation");
        yield return new WaitForSeconds(1f);
        canSwitch = true;
        myAnimator.Play("LeverStatic");
    }
}

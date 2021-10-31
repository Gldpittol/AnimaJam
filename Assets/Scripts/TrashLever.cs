using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashLever : MonoBehaviour
{
    private bool isTouching = false;
    private Animator myAnimator;
    private bool canSwitch = true;
    [SerializeField] private AudioClip interactClip;

    private bool isUsed = false;
    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isUsed) return;
        
        if (Input.GetKeyDown(KeyCode.F) && isTouching && canSwitch)
        {
            isUsed = true;
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
        AudioManager.Instance.PlayClip(interactClip);
        myAnimator.Play("LeverAnimation");
        yield return new WaitForSeconds(1f);
        canSwitch = true;
        myAnimator.Play("LeverStatic");
    }
}

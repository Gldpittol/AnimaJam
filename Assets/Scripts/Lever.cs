using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private List<Light> associatedLightsList = new List<Light>();

    private bool isTouching = false;
    private Animator myAnimator;
    private bool canSwitch = true;

    [SerializeField] private AudioClip interactClip;

    public bool isType2;
    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isTouching && canSwitch)
        {
            if (LightsPuzzleManager.Instance.isPuzzleCompleted) return;

            if (!isType2)
            {
                foreach (Light light in associatedLightsList)
                {
                    light.SwitchState();
                }

                StartCoroutine(FlipSwitchCoroutine());
                LightsPuzzleManager.Instance.CheckIfPuzzleCompleted();
            }

            else
            {
                foreach (Light light in associatedLightsList)
                {
                    light.SwitchStateType2();
                }
                StartCoroutine(FlipSwitchCoroutine());
                LightsPuzzleManager.Instance.CheckIfPuzzleCompletedType2();
            }
          
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

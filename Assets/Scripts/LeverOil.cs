using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverOil : MonoBehaviour
{
    private bool isTouching = false;
    private Animator myAnimator;
    private bool canSwitch = true;

    [SerializeField] private AudioClip interactClip;

    public GameObject OilImage;
    public float delay = 2f;
    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isTouching && canSwitch)
        {
             OilImage.SetActive(true);
             StartCoroutine(FlipSwitchCoroutine());
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
        GameController.Instance.gameState = GameState.Cutscene;
        canSwitch = false;
        AudioManager.Instance.PlayClip(interactClip);
        myAnimator.Play("LeverAnimation");
        yield return new WaitForSeconds(1f);
        myAnimator.Play("LeverStatic");

        yield return new WaitForSeconds(delay);
        GameController.Instance.SwapLevel("Credits");
    }
}

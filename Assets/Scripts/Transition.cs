using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public bool isOut = true;
    public GameObject myMask;
    public float transitionDuration;
    private Camera mainCamera;
    public void Awake()
    { 
        if(isOut) StartCoroutine(CircleOut());
        else StartCoroutine(CircleIn());
        
        mainCamera = Camera.main;
    }

    private void Update()
    {
        transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y);
    }

    public IEnumerator CircleOut()
    {
        GameController.Instance.gameState = GameState.Cutscene;

        myMask.transform.localScale = Vector3.zero;;
        yield return new WaitForSeconds(0.5f);

        while (myMask.transform.localScale.x < 1)
        {
            float toAdd = 1 / transitionDuration * Time.deltaTime;
            myMask.transform.localScale += new Vector3(toAdd, toAdd, toAdd);
            yield return null;
        }
        
        GameController.Instance.gameState = GameState.Gameplay;
        Destroy(gameObject);
    }

    public IEnumerator CircleIn()
    {
        GameController.Instance.gameState = GameState.Cutscene;
        
        myMask.transform.localScale = Vector3.one;;

        while (myMask.transform.localScale.x > 0)
        {
            float toAdd = 1 / transitionDuration * Time.deltaTime;
            myMask.transform.localScale -= new Vector3(toAdd, toAdd, toAdd);
            yield return null;
        }
        myMask.transform.localScale = Vector3.zero;;

        yield return new WaitForSeconds(0.3f);
    }
    
}

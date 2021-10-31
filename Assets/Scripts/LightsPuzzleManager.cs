using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LightsPuzzleManager : MonoBehaviour
{
    public static LightsPuzzleManager Instance;
    
    [SerializeField] private List<Light> lightsList = new List<Light>();
    [SerializeField] private GameObject minimapIcon;
    [SerializeField] private GameObject trashGate;
    [SerializeField] private AudioClip gateClip;

    public bool isPuzzleCompleted = false;
    
    private void Awake()
    {
        Instance = this;
    }

    public void CheckIfPuzzleCompleted()
    {
        bool isCompleted = true;
        
        foreach (Light light in lightsList)
        {
            if (!light.IsOn) isCompleted = false;
        }

        if (isCompleted)
        {
            isPuzzleCompleted = true;
            minimapIcon.SetActive(false);
            TrashPuzzle.Instance.EndTrashSpawn();
            trashGate.transform.rotation = Quaternion.Euler(0,0,52f);
            AudioManager.Instance.PlayClip(gateClip);
        }
    }
}

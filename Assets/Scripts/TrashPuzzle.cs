using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class TrashPuzzle : MonoBehaviour
{
    public static TrashPuzzle Instance;
    
    [SerializeField] private float delayBetweenTrashSpawns;
    [SerializeField] private float minPosX, maxPosX;
    [SerializeField] private float posY;
    [SerializeField] private List<GameObject> trashPrefabs = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
        StartCoroutine(SpawnTrashCoroutine());
    }

    public void SpawnTrash()
    {
        int rndTrash = Random.Range(0, trashPrefabs.Count);
        float rndPosX = Random.Range(minPosX, maxPosX);
        float rndRotation = Random.Range(0, 360);

        GameObject temp = Instantiate(trashPrefabs[rndTrash], new Vector2(rndPosX, posY), Quaternion.Euler(0,0,rndRotation));
        Destroy(temp, 20);
    }

    public void EndTrashSpawn()
    {
        StopAllCoroutines();
    }

    public IEnumerator SpawnTrashCoroutine()
    {
        SpawnTrash();
        yield return new WaitForSeconds(delayBetweenTrashSpawns);
        StartCoroutine(SpawnTrashCoroutine());
    }
}

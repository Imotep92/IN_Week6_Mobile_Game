using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class GameManger : MonoBehaviour
{

    public List<GameObject> targets; 
    private float spawnRate = 1.0f;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnTarget()); //calling 'SpawnTarget' Coroutine
    }

    IEnumerator SpawnTarget() //return coroutine method to spawn targets
    {
        while (true) // Every 1 second, coroutine will instantiate 1 random gameObject part of the of targets' list
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

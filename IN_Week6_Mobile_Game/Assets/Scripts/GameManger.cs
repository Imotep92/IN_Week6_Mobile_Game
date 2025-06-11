using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro.EditorUtilities;
using UnityEngine.SocialPlatforms.Impl;


public class GameManger : MonoBehaviour
{

    public List<GameObject> targets; // GameObjects in the "targets' list
    private float spawnRate = 1.0f; // 'targets' spawn every 1 sec

    private int score; // Player's score
    public TextMeshProUGUI scoreText; //score UI displayed on Screen


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnTarget()); //calling 'SpawnTarget' Coroutine
        UpdateScore(0); //Score is zero upon game starting
        
    }

    public void SwitchScene(int sceneIndex) // method to switch gamescenes
    {
        SceneManager.LoadScene(sceneIndex);
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

    public void UpdateScore(int scoreToAdd) // method to update score on game scene
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

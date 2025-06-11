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

   // private int lives = 3; // Player's lives

    public TextMeshProUGUI livesText; // lives UI displayed on screen

    public GameObject gameOverPanel; // Game Over UI to display on screen

    public bool isGameActive;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isGameActive = true;// initialise isGameActive bool, setting to true
        //lives = 3;
        StartCoroutine(SpawnTarget()); //calling 'SpawnTarget' Coroutine
        UpdateScore(0); //Score is zero upon game starting
        
    }

    public void RestartGame() // method to switch gamescenes
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator SpawnTarget() //return coroutine method to spawn targets
    {
        while (isGameActive) // Every 1 second isGameActive bool is set to 'true', coroutine will instantiate 1 random gameObject part of the of targets' list
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

   /* public void UpdateLives(int livesToTake)
    {
        lives -= livesToTake;
        livesText.text = "lives: " + lives;
        
    }*/

    public void GameOver() // method to display Game Over text in GameManager.cs
    {
        gameOverPanel.gameObject.SetActive(true);
        isGameActive = false; //setting isgameActive bool to false
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

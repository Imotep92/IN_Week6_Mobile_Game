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
    private float spawnRate = 1.5f; // 'targets' spawn every 1.5 sec


    private int score; // Player's score
    public int lives; // Player's lives
    public TextMeshProUGUI scoreText; //score UI displayed on Screen
    public TextMeshProUGUI livesText; // lives UI displayed on screen
    public TextMeshProUGUI finalScoreText, highScoreText; // "Finalscore" and "Highscore" text displayed in GameOver panel
    public GameObject TitleScreen; //Title sceen UI to display on screen

    public GameObject difficultyPanel;

    public GameObject gameOverPanel; // Game Over UI to display on screen
    public bool isGameActive; // bool determines whether the game is active

    /* public void SwitchScene() {SceneManager.LoadScene(1);} // method to switch scenes */
    
    void Start()
    {
        
    }

    public void StartGame( int difficulty)
    {
        TitleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
        isGameActive = true; // initialise isGameActive bool, setting to true
        UpdateLives(-3); // initialise lives
        StartCoroutine(SpawnTarget()); //calling 'SpawnTarget' Coroutine
        UpdateScore(0); // Score is zero upon game starting 
    }

    public void RestartGame() // method to restart active game scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator SpawnTarget() // return coroutine method to spawn targets
    {
        while (isGameActive) // Every 1.5 second isGameActive bool is set to 'true', coroutine will instantiate 1 random gameObject part of the of targets' list
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

    public void UpdateLives(int livesToTake) // method to update lives on game scene
    {
        if (isGameActive) // lives only coutdown whilst game is active
        {
            lives -= livesToTake;
            livesText.text = "lives: " + lives;
        }
    }

    public void GameOver() // method to display Game Over text in GameManager.cs
    {
        finalScoreText.text = "Final Score " + score;

        if (score > PlayerPrefs.GetInt("Highscore")) // if the final score is greater than the high score, replace highscore
        {
            PlayerPrefs.SetInt("Highscore", score);
        }

        highScoreText.text = "Highscore " + PlayerPrefs.GetInt("Highscore"); // most recent "Highscore" is displayed on the game over screen 

        isGameActive = false; // setting isgameActive bool to false
        gameOverPanel.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

/*EXAMPLE*/

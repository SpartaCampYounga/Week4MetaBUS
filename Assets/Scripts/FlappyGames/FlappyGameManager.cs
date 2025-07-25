using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyGameManager : MonoBehaviour
{
    static FlappyGameManager flappyGameManager;

    public static FlappyGameManager Instance
    {
        get { return flappyGameManager; }
    }
    
    private int currentScore = 0;
    
    private void Awake()
    {
        flappyGameManager = this;
    }
    
    public void GameOver()
    {
        Debug.Log("Game Over");
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
                
        Debug.Log("Score: " + currentScore);
    }
    
}
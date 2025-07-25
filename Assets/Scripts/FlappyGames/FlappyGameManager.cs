using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.Burst.Intrinsics.X86;

public class FlappyGameManager : MonoBehaviour
{
    public static FlappyGameManager flappyGameManager;

    private FlappyUIManager flappyUIManager;

    public static FlappyGameManager Instance
    {
        get { return flappyGameManager; }
    }
    
    private int currentScore = 0;
    
    private void Awake()
    {
        flappyGameManager = this;
    }
    private void Start()
    {
        flappyUIManager = FlappyUIManager.Instance;
        Time.timeScale = 0f;    //Ω√∞£ ∏ÿ√ﬂ±‚
        flappyUIManager.SetState(UIState.FlappyStart);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        flappyUIManager.SetState(UIState.FlappyEnd);
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        flappyUIManager.SetState(UIState.FlappyGame);
        flappyUIManager.FlappyGameUI.UpdateScore(0);
    }
    public void EndGame()
    {
        GameManager.Instance.ReturnFromFlappyGame();
    }

    public void AddScore(int score)
    {
        currentScore += score;

        flappyUIManager.FlappyGameUI.UpdateScore(currentScore);

        Debug.Log("Score: " + currentScore);
    }
    
}
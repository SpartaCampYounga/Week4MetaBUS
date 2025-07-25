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
        Time.timeScale = 0f;    //시간 멈추기    //초반 프레임은 재생됬다가 멈추는 중.. 개선 필요함.
        flappyUIManager.SetState(UIState.FlappyStart);
    }

    public void GameOver()
    {
        if(PlayerPrefs.HasKey("BestScore"))
        {
            if(currentScore > PlayerPrefs.GetInt("BestScore"))
            {
                PlayerPrefs.SetInt("BestScore", currentScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
        }
        PlayerPrefs.Save();
        Debug.Log("Game Over");
        Debug.Log("Current Score: " + currentScore);
        Debug.Log("Current After Game Over: " + PlayerPrefs.GetInt("BestScore"));
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

        //Debug.Log("Score: " + currentScore);
    }
    
}
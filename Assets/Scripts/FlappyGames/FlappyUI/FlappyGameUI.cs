using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlappyGameUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
    }
    protected override UIState GetUIState()
    {
        return UIState.FlappyGame;
    }
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString() + " away from where you belong";
    }
}

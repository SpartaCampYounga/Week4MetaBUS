using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private Button okButton;

    private void Awake()
    {
        //this.gameObject.SetActive(false);   //초기에는 꺼두기
        okButton.onClick.AddListener(OnClickOkButton);
    }

    protected override UIState GetUIState()
    {
        return UIState.ScoreBoard;
    }

    public void OnClickOkButton()
    {
        this.gameObject.SetActive(false);
    }
    public void UpdateScoreText()
    {
        if(PlayerPrefs.HasKey("LastScore"))
        {
            scoreText.text = PlayerPrefs.GetInt("LastScore").ToString();
        }
        else
        {
            scoreText.text = "0";  //기본값 설정
        }
    }
    public void UpdateBestScoreText()
    {
        if(PlayerPrefs.HasKey("BestScore"))
        {
            bestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
        }
        else
        {
            bestScoreText.text = "0";  //기본값 설정
        }
    }
}

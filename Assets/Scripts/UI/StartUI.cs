using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : BaseUI
{
    [SerializeField] private Button startButton;

    private void Awake()
    {
        startButton.onClick.AddListener(OnClickStartButton);
    }

    protected override UIState GetUIState()
    {
        return UIState.Start;
    }

    public void OnClickStartButton()
    {
        GameManager.Instance.StartGame();
    }
    public void OnEnable()  //StartUI가 활성화될 때 플레이어 입력을 비활성화
    {
        GameManager.Instance.SetPlayerInput(false);
    }
    public void OnDisable() //StartUI가 비활성화될 때 플레이어 입력을 활성화
    {
        GameManager.Instance.SetPlayerInput(true);
    }
}

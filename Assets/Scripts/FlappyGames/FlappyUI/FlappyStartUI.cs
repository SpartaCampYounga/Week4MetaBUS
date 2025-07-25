using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlappyStartUI : BaseUI
{
    [SerializeField] private Button startButton;


    private void Awake()
    {
        startButton.onClick.AddListener(OnClickStartButton);
    }
    protected override UIState GetUIState()
    {
        return UIState.FlappyStart;
    }

    public void OnClickStartButton()
    {
        FlappyGameManager.Instance.StartGame();
    }
}

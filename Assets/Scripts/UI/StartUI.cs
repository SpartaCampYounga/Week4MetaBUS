using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : BaseUI
{
    [SerializeField] private Button startButton;
    private void Start()
    {

    }
    public override void Init(UIManager uIManager)
    {
        base.Init(uIManager);

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
}

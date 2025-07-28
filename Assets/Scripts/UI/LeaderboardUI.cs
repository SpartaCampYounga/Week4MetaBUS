using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI message;
    [SerializeField] private Button closeButton;

    public bool? userResponse { get; private set; }
    private void Awake()
    {
        closeButton.onClick.AddListener(OnClickCloseButton);
    }
    protected override UIState GetUIState()
    {
        return UIState.Leaderboard;
    }

    public IEnumerator WaitForDialogueResponse(string message, Action<bool> callback)
    {
        this.SetActive(GetUIState());   //현재 다이얼로그 액티브
        this.message.text = message;
        userResponse = null;

        yield return new WaitUntil(() => userResponse.HasValue);

        Debug.Log(userResponse + " 눌림");
        this.gameObject.SetActive(false);
        callback.Invoke(userResponse.Value);    //Nullable이므로 값만.
    }
    public void OnClickCloseButton()
    {
        userResponse = false;
    }

}


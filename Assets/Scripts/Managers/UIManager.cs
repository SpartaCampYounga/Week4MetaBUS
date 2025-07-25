using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance { get; private set; }

    public StartUI StartUI { get; private set; }
    public MainUI MainUI { get; private set; }
    public DialogueUI DialogueUI{ get; private set; }
    public ScoreBoardUI ScoreBoardUI { get; private set; }
    public UIState currentState { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        StartUI = GetComponentInChildren<StartUI>(true);
        MainUI = GetComponentInChildren<MainUI>(true);
        DialogueUI = GetComponentInChildren<DialogueUI>(true);
        ScoreBoardUI = GetComponentInChildren<ScoreBoardUI>(true);
    }
    

    public void SetState(UIState uIState)
    {
        currentState = uIState;
        StartUI.SetActive(currentState);
        MainUI.SetActive(currentState);
        //ScoreBoardUI.SetActive(currentState); 메인이랑 겹쳐보이게 할거임...
    }

    public void StartDialogueCoroutine(string message, Action<bool> callback)  //닫는 건 버튼 통해서 하면 됨.
    {
        StartCoroutine(DialogueUI.WaitForDialogueResponse(message, callback));
    }

    public void ActivateGameMessageUI(string message)   //내부 displayTime 후에 꺼지도록 해뒀음.
    {
        MainUI.DisplayGameMessage(message);
    }

    public void ShowScoreBoard()
    {
        ScoreBoardUI.gameObject.SetActive(true);
        ScoreBoardUI.UpdateScoreText();
        ScoreBoardUI.UpdateBestScoreText();
    }
}

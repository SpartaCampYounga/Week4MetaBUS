using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIState
{
    Start,
    Main,
    Dialogue
}
public class UIManager : MonoBehaviour
{

    public static UIManager Instance { get; private set; }

    public StartUI StartUI { get; private set; }
    public MainUI MainUI { get; private set; }
    public DialogueUI DialogueUI{ get; private set; }
    private UIState currentState;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);  // 혹시 모를 게임매니저 복제 대응

        StartUI = GetComponentInChildren<StartUI>(true);
        MainUI = GetComponentInChildren<MainUI>(true);
        DialogueUI = GetComponentInChildren<DialogueUI>(true);
    }
    

    public void SetState(UIState uIState)
    {
        currentState = uIState;
        StartUI.SetActive(currentState);
        MainUI.SetActive(currentState);
    }

    public void StartDialogueCoroutine(string message, Action<bool> callback)  //닫는 건 버튼 통해서 하면 됨.
    {
        StartCoroutine(DialogueUI.WaitForDialogueResponse(message, callback));
    }

    public void ActivateGameMessageUI(string message)   //내부 displayTime 후에 꺼지도록 해뒀음.
    {
        MainUI.DisplayGameMessage(message);
    }
}

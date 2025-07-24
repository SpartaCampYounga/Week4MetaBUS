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
    
    StartUI startUI;
    MainUI mainUI;
    DialogueUI dialogueUI;
    public DialogueUI DialogueUI => dialogueUI; 
    private UIState currentState;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);  // 혹시 모를 게임매니저 복제 대응

        startUI = GetComponentInChildren<StartUI>(true);
        startUI.Init(this); //싱글턴 구현했으므로 this 안넘기는 쪽으로 수정해야함
        mainUI = GetComponentInChildren<MainUI>(true);
        mainUI.Init(this);
        dialogueUI = GetComponentInChildren<DialogueUI>(true);
        dialogueUI.Init(this);
    }

    public void SetState(UIState uIState)
    {
        currentState = uIState;
        startUI.SetActive(currentState);
        mainUI.SetActive(currentState);
        dialogueUI.SetActive(currentState);
    }
}

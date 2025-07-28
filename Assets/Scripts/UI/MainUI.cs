using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : BaseUI
{
    [SerializeField] private Image gameMessageBox;
    [SerializeField] private TextMeshProUGUI gameMessageText;
    [SerializeField] private Interactable interactableDisplay;
    private float displayTime = 1.5f;

    private void Awake()
    {
        gameMessageBox.gameObject.SetActive(false);    //처음엔 꺼두기
        interactableDisplay.gameObject.SetActive(false);
    }

    protected override UIState GetUIState()
    {
        return UIState.Main;
    }
    public void DisplayGameMessage(string message)
    {
        gameMessageText.text = message;
        gameMessageBox.gameObject.SetActive(true);
        Invoke("CloseGameMessage", displayTime);    //시간 지나면 닫힘 호출
    }
    public void CloseGameMessage()
    {
        gameMessageText.text = "";
        gameMessageBox.gameObject.SetActive(false);
    }
    public void DisplayInteractable(bool isInteractable)
    {
        // Debug.Log("public void DisplayInteractable(bool isInteractable)" + isInteractable);
        if (isInteractable)
            interactableDisplay.gameObject.SetActive(true);
        else
            interactableDisplay.gameObject.SetActive(false);
    }

}

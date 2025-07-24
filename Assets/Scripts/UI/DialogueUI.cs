using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI message;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;
    private void Start()
    {

    }
    protected override UIState GetUIState()
    {
        return UIState.Dialogue;
    }

    public void DisplayDialogue(string message)
    {
        this.message.text = message;
    }

}

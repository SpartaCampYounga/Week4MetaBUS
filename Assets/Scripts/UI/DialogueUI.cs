using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI message;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;

    public bool? userResponse { get; private set; }
    private void Awake()
    {
        yesButton.onClick.AddListener(OnClickYesButton);
        noButton.onClick.AddListener(OnClickNoButton);
    }
    protected override UIState GetUIState()
    {
        return UIState.Dialogue;
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

    public void OnClickYesButton()
    {
        userResponse = true;
    }
    public void OnClickNoButton()
    {
        userResponse = false;
    }

}

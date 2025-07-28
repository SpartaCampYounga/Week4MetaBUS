using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : BaseController
{
    [SerializeField] private PlayerInput playerInput;
    protected override void Start()
    {
        base.Start();
    }

    protected override void HandleAction()
    {

    }
    public void SetPlayerInput(bool isEnable) 
    {
        if(playerInput == null)
        {
            Debug.LogError("PlayerInput is not assigned in PlayerController.");
            return;
        }

        if (isEnable)
            playerInput.ActivateInput();
        else
            playerInput.DeactivateInput();
    }
    void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }

    void OnInteract(InputValue inputValue)
    {
        if (inputValue.isPressed)   //누를때, 뗄 때 두번 호출되서 isPressed로 체크 //Q.전 강의에서는 true로 계속 호출되었던 것 같은데, 왜 여기는 누를때, 뗄때 두번만 호출되지?
        {
            if (GameManager.Instance.isNextToWaterOfLife)   //생명수
            {
                Debug.Log("Trying to interact: " + inputValue.isPressed);
                string message = "Are you sure to drink this WATER OF LIFE?";
                UIManager.Instance.SetState(UIState.Dialogue);
                UIManager.Instance.StartDialogueCoroutine(message, (bool response) =>
                {
                    if (response)
                    {
                        GameManager.Instance.EnterFlappyGame();
                    }
                    else
                    {
                        string message = "Okay, it looks safer not to drink";
                        UIManager.Instance.ActivateGameMessageUI(message);
                    }
                });
            }
            else if (GameManager.Instance.isNextToWizzard)  //마법사
            {
                Debug.Log("Trying to interact: " + inputValue.isPressed);
                string message = "Do you want me to show you how much you've explored that world?";
                UIManager.Instance.SetState(UIState.Dialogue);
                UIManager.Instance.StartDialogueCoroutine(message, (bool response) =>
                {
                    if (response)
                    {
                        UIManager.Instance.ShowScoreBoard();
                    }
                    else
                    {
                        //그냥 아무것도 안함.
                    }
                });
            }
            else
            {
                string message = "Nope, you're not around anything to interact.";
                UIManager.Instance.ActivateGameMessageUI(message);
            }
        }
    }
}

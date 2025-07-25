using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : BaseController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void HandleAction()
    {

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
            if (GameManager.Instance.isNextToWaterOfLife)
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
            else
            {
                string message = "Nope, you're not around the Water Of Life";
                UIManager.Instance.ActivateGameMessageUI(message);
            }
        }
    }
}

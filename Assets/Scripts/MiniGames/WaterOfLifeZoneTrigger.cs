using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterOfLifeZoneTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.isNextToWaterOfLife = true;
        string message = "Are you sure to drink this WATER OF LIFE?";
        ////////////////////////////////////////////이거 여기서 하는거 아님. 위치 고민해보기.
        //////////////////또 Dialogue는 SetState에서 하면 안될듯. 개별적으로 껏다켯다 해야함.
        UIManager.Instance.SetState(UIState.Dialogue);
        UIManager.Instance.DialogueUI.DisplayDialogue(message);
        // Debug.Log("GameManager.Instance.isNextToWaterOfLife is " + GameManager.Instance.isNextToWaterOfLife);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameManager.Instance.isNextToWaterOfLife = false;
        // Debug.Log("GameManager.Instance.isNextToWaterOfLife is " + GameManager.Instance.isNextToWaterOfLife);
    }
}

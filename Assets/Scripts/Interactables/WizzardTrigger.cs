using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizzardTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.isNextToWizzard = true;
        GameManager.Instance.ShowInteractable(true);
        // Debug.Log("GameManager.Instance.isNextToWaterOfLife is " + GameManager.Instance.isNextToWaterOfLife);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameManager.Instance.isNextToWizzard = false;
        GameManager.Instance.ShowInteractable(false);
        // Debug.Log("GameManager.Instance.isNextToWaterOfLife is " + GameManager.Instance.isNextToWaterOfLife);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterOfLifeZoneTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.isNextToWaterOfLife = true;
        // Debug.Log("GameManager.Instance.isNextToWaterOfLife is " + GameManager.Instance.isNextToWaterOfLife);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameManager.Instance.isNextToWaterOfLife = false;
        // Debug.Log("GameManager.Instance.isNextToWaterOfLife is " + GameManager.Instance.isNextToWaterOfLife);
    }
}

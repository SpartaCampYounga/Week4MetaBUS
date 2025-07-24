using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterOfLifeZoneTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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

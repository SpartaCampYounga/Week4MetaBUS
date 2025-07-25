using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyUIManager : MonoBehaviour
{
    public static FlappyUIManager Instance { get; private set; }

    public FlappyStartUI FlappyStartUI { get; private set; }
    public FlappyGameUI FlappyGameUI { get; private set; }
    public FlappyEndUI FlappyEndUI { get; private set; }

    private UIState currentState;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        FlappyStartUI = GetComponentInChildren<FlappyStartUI>(true);
        FlappyGameUI = GetComponentInChildren<FlappyGameUI>(true);
        FlappyEndUI = GetComponentInChildren<FlappyEndUI>(true);
    }
    public void SetState(UIState uIState)
    {
        currentState = uIState;
        FlappyStartUI.SetActive(currentState);
        FlappyGameUI.SetActive(currentState);
        FlappyEndUI.SetActive(currentState);
    }
}

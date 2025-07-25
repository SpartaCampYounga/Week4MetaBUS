using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyUIManager : MonoBehaviour
{
    public static FlappyUIManager Instance { get; private set; }

    public StartUI StartUI { get; private set; }
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

        StartUI = GetComponentInChildren<StartUI>(true);
    }
    
    public void SetState(UIState uIState)
    {
        currentState = uIState;
        StartUI.SetActive(currentState);
    }
}

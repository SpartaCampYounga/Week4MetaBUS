using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlappyEndUI : BaseUI
{
    private void Awake()
    {
    }
    protected override UIState GetUIState()
    {
        return UIState.FlappyEnd;
    }
}

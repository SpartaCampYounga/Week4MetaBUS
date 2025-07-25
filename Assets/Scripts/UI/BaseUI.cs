using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    // protected UIManager uIManager;

    // public virtual void Init()
    // {
    //     // this.uIManager = uIManager;  //UIManager 싱글톤 처리하여 제거함
    // }

    protected abstract UIState GetUIState();

    public void SetActive(UIState state)
    {
        this.gameObject.SetActive(GetUIState() == state);
    }
}

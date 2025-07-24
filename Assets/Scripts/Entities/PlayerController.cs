using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
        Debug.Log("Trying to interact");
    }
}

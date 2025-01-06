using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private void Start()
    {
        var input = new PlayerInputActions();
        input.Enable();
        input.Movement.Enable();
        input.Movement.Test.performed += OnPerformed;
    }

    private void OnPerformed(InputAction.CallbackContext obj)
    {
        SFXManager.Instance.PlaySound("test");
    }

    private void Update()
    {
        
    }
}

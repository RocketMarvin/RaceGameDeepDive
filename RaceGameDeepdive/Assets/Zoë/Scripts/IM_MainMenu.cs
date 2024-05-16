using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IM_MainMenu : MonoBehaviour
{
    public static IM_MainMenu instance;

    public bool MenuOpenCloseInput { get; private set; }

    private PlayerInput _playerInput;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _playerInput = GetComponent<PlayerInput>();
    }
}

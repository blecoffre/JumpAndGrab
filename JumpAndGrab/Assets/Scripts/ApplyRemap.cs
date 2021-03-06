﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ApplyRemap : MonoBehaviour
{
    public Button okButton;
    public InputActionAsset tanksInputActions;
    private InputActionMap playerActionMap;

    void Start()
    {
        playerActionMap = tanksInputActions.FindActionMap("Player");
        playerActionMap.Disable();
        okButton.onClick.AddListener(OkButtonClicked);
    }

    private void OkButtonClicked()
    {
        playerActionMap.Enable();
    }
}

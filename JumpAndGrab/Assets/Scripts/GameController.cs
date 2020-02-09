using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private CustomInputs controls;

    [SerializeField]
    private InGameMenuViewController m_ingameMenuViewController;

    [SerializeField]
    private PlayerController player;

    void Awake()
    {
        controls = new CustomInputs();
        player.controls = controls;
        controls.ExtraControls.OpenMenu.performed += ctx => FlipFlopMainMenu();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void FlipFlopMainMenu()
    {
        Debug.Log("CC");
        m_ingameMenuViewController.FlipFlopMainMenu();
    }
}

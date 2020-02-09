using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuViewController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_ingamMainMenu = default;

    void Start()
    {
        
    }

    public void FlipFlopMainMenu()
    {
        Action method = (m_ingamMainMenu.activeSelf ? (Action)CloseMainMenu : OpenMainMenu);
        method();
    }


    private void OpenMainMenu()
    {
        m_ingamMainMenu?.SetActive(true);
    }

    private void CloseMainMenu()
    {
        m_ingamMainMenu?.SetActive(false);
    }
}

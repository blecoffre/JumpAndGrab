﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterractableWithTrigger : IInteractable
{
    //private void OnTriggerEnter(Collider other)
    //{
    //    m_actionOnEnter.InvokeIfNotNull();
    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    m_actionOnStay.InvokeIfNotNull();
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    m_actionOnExit.InvokeIfNotNull();
    //}

    public bool CanInteract<T>(T data)
    {
        throw new System.NotImplementedException();
    }

    public void Interact()
    {
        throw new System.NotImplementedException();
    }
}

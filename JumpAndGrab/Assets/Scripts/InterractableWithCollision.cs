using UnityEngine;
using System;
using UnityEngine.Events;

[Serializable]
public class InterractableWithCollision : MonoBehaviour, IInteractable
{
    [SerializeField]
    private Collider m_collider;

    public UnityEvent m_actionOnEnter;

    public Condition[] EnterConditions;

    private void Awake()

    {  //If no collider, disable script to avoid error
        if (!m_collider)
            this.enabled = false;

        m_actionOnEnter.AddListener(() => Debug.Log("Enter collision"));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (CanInteract(collision))
        {
            Interact();
        }
    }

    public bool CanInteract<Collision>(Collision collision)
    {
        return ConditionSystemManager.CheckConditions(EnterConditions, gameObject, gameObject);
    }

    public void Interact()
    {
        m_actionOnEnter.InvokeIfNotNull();
    }
}

using UnityEngine;
using UnityEngine.Events;

public class Interractable : MonoBehaviour
{
    [SerializeField]
    private Collider m_collider;

    public UnityAction m_actionOnEnter;
    public UnityAction m_actionOnStay;
    public UnityAction m_actionOnExit;

    private void Awake()
    {
        //If no collider, disable script to avoid error
        if (!m_collider)
            this.enabled = false;
    }
}

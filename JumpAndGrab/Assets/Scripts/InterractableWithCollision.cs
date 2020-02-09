using UnityEngine;

public class InterractableWithCollision : Interractable
{
    public Condition[] Conditions;
    private void OnCollisionEnter(Collision collision)
    {
        m_actionOnEnter.InvokeIfNotNull();
    }

    private void OnCollisionStay(Collision collision)
    {
        m_actionOnStay.InvokeIfNotNull();
    }

    private void OnCollisionExit(Collision collision)
    {
        m_actionOnExit.InvokeIfNotNull();
    }
}

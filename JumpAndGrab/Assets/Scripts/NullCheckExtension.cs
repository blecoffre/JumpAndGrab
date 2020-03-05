using UnityEngine;
using UnityEngine.Events;

public static class NullCheckExtension
{
    public static void InvokeIfNotNull(this UnityEvent action)
    {
        if (action != null)
            action.Invoke();
    }

    public static void SetActiveChecked(this GameObject gameObject, bool active)
    {
        if (gameObject != null && gameObject.activeSelf != active)
            gameObject.SetActive(active);
    }
}

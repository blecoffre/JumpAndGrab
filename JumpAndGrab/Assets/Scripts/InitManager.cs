using UnityEngine;

class InitManager : MonoBehaviour
{
    private void Awake()
    {
        
    }

    private void InitQueue()
    {
        ConditionSystemManager.Initialize();
    }
}


using UnityEngine;

public static class ConditionSystemManager
{
    
    public static void Initialize()
    {

    }

    /// <summary>
    /// Check if all conditions are met to perform an action
    /// </summary>
    /// <param name="conditions"></param> All required conditions
    /// <param name="first"></param> The object wich call the CheckConditions function
    /// <param name="second"></param> The target object, optionnal, depending of the need
    /// <returns></returns>
    public static bool CheckConditions(Condition[] conditions, GameObject first, GameObject second = null)
    {
        if (CheckConditionsAreValid(conditions))
        {
            if (first != null && (RequiredSecondObject(conditions) == (second != null ? true : false)))
            {
                for (int i = 0; i < conditions.Length; i++)
                {
                    if (conditions[i].ConditionType == ConditionType.HasTag)
                    {
                        if (!CheckTagCondition(conditions[i], second))
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                Debug.LogError("Missing first GameObject");
            }
        }
        else
        {
            Debug.LogError("Condition(s) are not valid");
        }
        return true;
    }

    private static bool CheckConditionsAreValid(Condition[] conditions)
    {
        if (conditions != null)
        {
            if (conditions.Length > 0)
            {
                for (int i = 0; i < conditions.Length; i++)
                {
                    if (CheckConditionTypeIsValid(conditions[i].ConditionType))
                    {
                        if (CheckConditionValueIsValid(conditions[i].ConditionValue))
                        {
                            if (CheckIfTypeAndValueMatch(conditions[i].ConditionType, conditions[i].ConditionValue))
                            {
                                if (CheckConditionTargetIsValid(conditions[i].ConditionTarget))
                                {
                                    return true;
                                }
                                else
                                {
                                    Debug.LogError("Condition Target is invalid : " + conditions[i].ConditionTarget);
                                    break;
                                }
                            }
                            else
                            {
                                Debug.LogError("Condition Type : " + conditions[i].ConditionType + " and Condition Value : " + conditions[i].ConditionValue + " dont match");
                                break;
                            }
                        }
                        else
                        {
                            Debug.LogError("Condition Value is invalid : " + conditions[i].ConditionValue);
                            break;
                        }
                    }
                    else
                    {
                        Debug.LogError("Condition Type is invalid : " + conditions[i].ConditionType);
                        break;
                    }
                }
            }
            else
            {
                Debug.Log("No conditions on array");
            }
        }
        else
        {
            Debug.Log("Conditions are null");
        }
        return false;
    }

    private static bool CheckConditionTypeIsValid(string type)
    {
        if (type == ConditionType.HasComponent || type == ConditionType.HasTag || type == ConditionType.TypeOf)
        {
            return true;
        }
        return false;
    }

    private static bool CheckConditionValueIsValid(string value)
    {
        if (value == ConditionValue.Player || value == ConditionValue.Enemy || value == ConditionValue.Interactable)
        {
            return true;
        }
        return false;
    }

    private static bool CheckConditionTargetIsValid(string target)
    {
        if (target == ConditionTarget.Self || target == ConditionTarget.Target || target == ConditionTarget.Specific)
        {
            return true;
        }
        return false;
    }

    private static bool CheckIfTypeAndValueMatch(string type, string value)
    {
        if (type == ConditionType.HasComponent)
        {
            if (value == null)
                return false;
        }
        else if (type == ConditionType.HasTag)
        {
            if (value == ConditionValue.Player || value == ConditionValue.Enemy)
            {
                return true;
            }
        }
        else if (type == ConditionType.TypeOf)
        {
            if (value == ConditionValue.Interactable)
            {
                return true;
            }
        }
        return false;
    }

    private static bool RequiredSecondObject(Condition[] conditions)
    {
        for (int i = 0; i < conditions.Length; i++)
        {
            if (conditions[i].ConditionType == ConditionType.HasComponent || conditions[i].ConditionType == ConditionType.TypeOf || conditions[i].ConditionType == ConditionType.HasTag &&
                conditions[i].ConditionTarget == ConditionTarget.Target || conditions[i].ConditionTarget == ConditionTarget.Specific)
            {
                return true;
            }
        }
        
        return false;
    }

    private static bool CheckTagCondition(Condition condition, GameObject second)
    {
        if (condition.ConditionType == ConditionType.HasTag && (condition.ConditionTarget == ConditionTarget.Target || condition.ConditionTarget == ConditionTarget.Specific) && second.tag == condition.ConditionValue)
        {
            return true;
        }

        return false;
    }


}

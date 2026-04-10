using System;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public List<ICondition> conditions  = new List<ICondition>();
    public List<IAction> actions = new List<IAction>();

    public IImpulse impulse;

    void Start()
    {
        impulse?.Arm(TryActivate);
    }

    void OnDestroy()
    {
        impulse?.Disarm();
    }

    public void TryActivate()
    {
        foreach (ICondition condition in conditions)
        {
            if (!condition.IsMet())
            {
                return;
            }
        }

        foreach (IAction action in actions)
        {
            action.DoAction();
        }
    }
}

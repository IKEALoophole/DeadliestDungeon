using System;
using System.Collections.Generic;
using UnityEngine;

public class Ability: MonoBehaviour
{
    public List<ConditionBase> conditions  = new List<ConditionBase>();
    public List<ActionBase> actions = new List<ActionBase>();

    public ImpulseBase impulse;

    public void Init()
    {
        impulse?.Arm(TryActivate);
    }

    public void Cleanup()
    {
        impulse?.Disarm();
    }

    public void TryActivate()
    {
        print("Trying to activate abilitiesses");
        foreach (ConditionBase condition in conditions)
        {
            if (!condition.IsMet())
            {
                return;
            }
        }

        foreach (ActionBase action in actions)
        {
            action.DoAction();
        }
    }
}

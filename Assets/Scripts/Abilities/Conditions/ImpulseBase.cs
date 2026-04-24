using System;
using UnityEngine;
public abstract class ImpulseBase: MonoBehaviour
{
    public abstract void Arm(Action onTriggered);
    public abstract void Disarm();
}

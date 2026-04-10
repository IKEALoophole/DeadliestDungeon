using System;

public interface IImpulse
{
    void Arm(Action onTriggered);
    void Disarm();
}

using System;

public class OnPlayedImpulse : IImpulse
{
    private Card owner;
    private Action onTriggered;

    public OnPlayedImpulse(Card owner)
    {
        this.owner = owner;
    }

    public void Arm(Action onTriggered)
    {
        this.onTriggered = onTriggered;
        owner.onPlaced += onTriggered;
    }

    public void Disarm()
    {
        owner.onPlaced -= onTriggered;
        onTriggered = null;
    }
}
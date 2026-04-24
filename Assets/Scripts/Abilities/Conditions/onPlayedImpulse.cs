using System;

public class OnPlayedImpulse : ImpulseBase
{
    private Card owner;
    private Action onTriggered;

    public void Awake()
    {
        this.owner = transform.root.GetComponent<Card>();
    }

    public override void Arm(Action onTriggered)
    {
        this.onTriggered = onTriggered;
        owner.onPlaced += onTriggered;
    }

    public override void Disarm()
    {
        owner.onPlaced -= onTriggered;
        onTriggered = null;
    }

}
using UnityEngine;

public class AddDeadlinessAbility : ActionBase
{
    public int amount;

    public override void DoAction()
    {
        print("Doing ABILIRTY");
        GameManager.CardManager.AddDeadlinessToCard(transform.root.GetComponent<Card>(), amount);
    }

}
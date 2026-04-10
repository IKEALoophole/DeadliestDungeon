using UnityEngine;

public class AddDeadlinessAbility : MonoBehaviour, IAction
{
    public int amount;

    public void DoAction()
    {
        GameManager.CardManager.AddDeadlinessToCard(GetComponentInParent<Card>(), amount);
    }

}
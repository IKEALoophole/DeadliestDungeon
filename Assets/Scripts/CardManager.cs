using System;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    private Card currentEntrace;
    private List<Card> cards;

    public int FewestRoomsFromEntrace(Card card)
    {
        if(card == currentEntrace || card == null)
        {
            return 0;
        }
        return 1;//temp
    }

    public bool tryPlaceCard(Card card)
    {
        var cardPos = card.transform.position;
        var colliders = Physics2D.OverlapPointAll(cardPos);

        foreach (var collider in colliders)
        {
            if (collider.tag == "tileDrop")
            {
                card.placed = true;
                card.transform.position = collider.transform.position;
                switch (collider.gameObject.name)
                {

                    case "Ntrig":
                        collider.transform.parent.GetComponent<Card>().nCard = card;
                        card.sCard = collider.transform.parent.GetComponent<Card>();
                        Debug.Log("Placed card " + card.name + " to the north of " + collider.transform.parent.name);
                        break;
                    case "Strig":
                        collider.transform.parent.GetComponent<Card>().sCard = card;
                        card.nCard = collider.transform.parent.GetComponent<Card>();
                        Debug.Log("Placed card " + card.name + " to the south of " + collider.transform.parent.name);
                        break;
                    case "Etrig":
                        collider.transform.parent.GetComponent<Card>().eCard = card;
                        card.wCard = collider.transform.parent.GetComponent<Card>();
                        Debug.Log("Placed card " + card.name + " to the east of " + collider.transform.parent.name);
                        break;
                    case "Wtrig":
                        collider.transform.parent.GetComponent<Card>().wCard = card;
                        card.eCard = collider.transform.parent.GetComponent<Card>();
                        Debug.Log("Placed card " + card.name + " to the west of " + collider.transform.parent.name);
                        break;
                    default:
                        Debug.LogError("Tile drop trigger " + collider.gameObject.name + " does not have a valid name.");
                        break;
                }
                return true;
            }
        }
        Debug.Log("Could not place card " + card.name + " at position " + cardPos);
        return false;
    }

    public void AddDeadlinessToCard(Card card, int amount)
    {
        card.addDeadliness(amount);
    }
}

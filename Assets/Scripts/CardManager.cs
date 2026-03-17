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
                switch (collider.name)
                {
                    case "NTtrig":
                        card.nCard = collider.transform.parent.GetComponent<Card>();
                        break;
                    case "STtrig":
                        card.sCard = collider.transform.parent.GetComponent<Card>();
                        break;
                    case "ETtrig":
                        card.eCard = collider.transform.parent.GetComponent<Card>();
                        break;
                    case "WTtrig":
                        card.wCard = collider.transform.parent.GetComponent<Card>();
                        break;
                }
                Debug.Log("Placed card " + card.name + " on " + collider.gameObject.name);
                return true;
            }
        }
        Debug.Log("Could not place card " + card.name + " at position " + cardPos);
        //Debug.Log("Collider at position: " + (collider != null ? collider.gameObject.name : "None"));
        return false;
    }

    public void AddDeadlinessToCard(Card card, int amount)
    {
        card.addDeadliness(amount);
    }
}

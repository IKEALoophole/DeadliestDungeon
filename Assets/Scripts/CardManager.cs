using System;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    private Card currentEntrace;
    private List<Card> playedCards;
    private Deck playerDeck;

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
                
                switch (collider.gameObject.name)
                {

                    case "Ntrig":
                        if(!collider.transform.parent.GetComponent<Card>().nCard)
                        {
                            collider.transform.parent.GetComponent<Card>().nCard = card;
                            card.sCard = collider.transform.parent.GetComponent<Card>();
                            card.placed = true;
                            card.transform.position = collider.transform.position;
                        }
                        break;
                    case "Strig":
                        if(!collider.transform.parent.GetComponent<Card>().sCard)
                        {
                            collider.transform.parent.GetComponent<Card>().sCard = card;
                            card.nCard = collider.transform.parent.GetComponent<Card>();
                            card.placed = true;
                            card.transform.position = collider.transform.position;
                        }
                        break;
                    case "Etrig":
                        if(!collider.transform.parent.GetComponent<Card>().eCard)
                        {
                            collider.transform.parent.GetComponent<Card>().eCard = card;
                            card.wCard = collider.transform.parent.GetComponent<Card>();
                            card.placed = true;
                            card.transform.position = collider.transform.position;
                        }
                        break;
                    case "Wtrig":
                        if(!collider.transform.parent.GetComponent<Card>().wCard)
                        {
                            collider.transform.parent.GetComponent<Card>().wCard = card;
                            card.eCard = collider.transform.parent.GetComponent<Card>();
                            card.placed = true;
                            card.transform.position = collider.transform.position;
                        }
                        break;
                    default:
                        Debug.LogError("Tile drop trigger " + collider.gameObject.name + " does not have a valid name.");
                        break;
                }
                GameManager.Instance.updateDeadliness(card.GetDeadliness());
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

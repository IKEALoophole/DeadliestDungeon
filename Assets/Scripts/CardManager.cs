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
                Card colliderCard = collider.transform.root.GetComponent<Card>();
                Debug.Log("Trying to place card " + card.name + " on " + colliderCard.name + " at position " + cardPos);

                switch (collider.gameObject.name)
                {
                    case "Ntrig":
                        if(colliderCard.nCard == null && colliderCard.doorDirections.HasFlag(Card.DoorDirection.North)
                        && card.doorDirections.HasFlag(Card.DoorDirection.South))
                        {
                            Debug.Log("Great Success");
                            colliderCard.nCard = card;
                            card.sCard = colliderCard;
                            card.placed = true;
                            card.transform.position = collider.transform.position;
                        }
                        Debug.Log("BAD SUCCESS");
                        break;
                    case "Strig":
                        if(colliderCard.sCard == null && colliderCard.doorDirections.HasFlag(Card.DoorDirection.South)
                        && card.doorDirections.HasFlag(Card.DoorDirection.North) && colliderCard.placed)
                        {
                            Debug.Log("Great Success");
                            colliderCard.sCard = card;
                            card.nCard = colliderCard;
                            card.placed = true;
                            card.transform.position = collider.transform.position;
                        }
                        Debug.Log("BAD SUCCESS");
                        break;
                    case "Etrig":
                        if(colliderCard.eCard == null && colliderCard.doorDirections.HasFlag(Card.DoorDirection.East)
                        && card.doorDirections.HasFlag(Card.DoorDirection.West) && colliderCard.placed)
                        {
                            Debug.Log("Great Success");
                            colliderCard.eCard = card;
                            card.wCard = colliderCard;
                            card.placed = true;
                            card.transform.position = collider.transform.position;
                        }
                        Debug.Log("BAD SUCCESS");
                        break;
                    case "Wtrig":
                        if(colliderCard.wCard == null && colliderCard.doorDirections.HasFlag(Card.DoorDirection.West)
                        && card.doorDirections.HasFlag(Card.DoorDirection.East) && colliderCard.placed)
                        {
                            Debug.Log("Great Success");
                            colliderCard.wCard = card;
                            card.eCard = colliderCard;
                            card.placed = true;
                            card.transform.position = collider.transform.position;
                        }
                        Debug.Log("BAD SUCCESS");
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

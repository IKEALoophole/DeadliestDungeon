using System;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();

    public void AddCard(Card card)
    {
        deck.Add(card);
    }

    public Card PopCard()
    {
        if (deck.Count > 0)
        {
            Card card = deck[deck.Count - 1];
            deck.RemoveAt(deck.Count - 1);
            return card;
        }
        else
        {
            throw new InvalidOperationException("Deck is empty");
        }
    }
}

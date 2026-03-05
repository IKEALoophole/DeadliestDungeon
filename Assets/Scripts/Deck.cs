using System;
using System.Collections;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public ArrayList deck = new ArrayList();

    public void AddCard(int card)
    {
        deck.Add(card);
    }

    public int PopCard()
    {
        if (deck.Count > 0)
        {
            int card = (int)deck[0];
            deck.RemoveAt(0);
            return card;
        }
        else
        {
            throw new InvalidOperationException("Deck is empty");
        }
    }
}

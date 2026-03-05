using System;
using UnityEngine;

public class CardManager : MonoBehaviour
{
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
                Debug.Log("Placed card " + card.name + " on " + collider.gameObject.name);
                return true;
            }
        }
        Debug.Log("Could not place card " + card.name + " at position " + cardPos);
        //Debug.Log("Collider at position: " + (collider != null ? collider.gameObject.name : "None"));
        return false;
    }
}

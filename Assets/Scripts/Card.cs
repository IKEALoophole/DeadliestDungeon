using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Card : MonoBehaviour
{
    public bool placed = false;
    public CardManager cardManager;
    [SerializeField]
    private int deadliness = 0;

    public Card nCard;
    public Card sCard;
    public Card eCard;
    public Card wCard;

    [Flags]
    public enum CardType
    {
        None = 0,
        Entrance = 1,
        Treasure = 2,
        Monster = 4,
        Trap = 8,
        Shrine = 16,
        Alchemy = 32,
        Hall = 64
    }

    public CardType types;

    public void addDeadliness(int amount)
    {
        deadliness += amount;
    }

    public int GetDeadliness()
    {
        return deadliness;
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    /*public List<GameObject> GetTriggers()
    {
        List<GameObject> triggers = new List<GameObject>();
        foreach (Transform child in transform)
        {
            if (child.CompareTag("tileDrop"))
            {
                triggers.Add(child.gameObject);
            }
        }
        return triggers;
    }*/
}

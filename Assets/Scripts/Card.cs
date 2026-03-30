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
    [SerializeField]
    private TMPro.TextMeshProUGUI cardNameText;
    [SerializeField]
    private String cardName;

    public GameObject nDoor;
    public GameObject sDoor;
    public GameObject wDoor;
    public GameObject eDoor;

    public GameObject nWall;
    public GameObject sWall;
    public GameObject wWall;
    public GameObject eWall;

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

    [Flags]
    public enum DoorDirection
    {
        None = 0,
        North = 1,
        South = 2,
        East = 4,
        West = 8
    }

    public CardType types;
    public DoorDirection doorDirections;

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

    public void UpdateDoors()
    {
        nDoor.SetActive(doorDirections.HasFlag(DoorDirection.North));
        sDoor.SetActive(doorDirections.HasFlag(DoorDirection.South));
        eDoor.SetActive(doorDirections.HasFlag(DoorDirection.East));
        wDoor.SetActive(doorDirections.HasFlag(DoorDirection.West));
        nWall.SetActive(!doorDirections.HasFlag(DoorDirection.North));
        sWall.SetActive(!doorDirections.HasFlag(DoorDirection.South));
        eWall.SetActive(!doorDirections.HasFlag(DoorDirection.East));
        wWall.SetActive(!doorDirections.HasFlag(DoorDirection.West));
    }

    public void Start()
    {
        UpdateDoors();
        if (cardNameText != null)
            cardNameText.text = cardName;
    }

    public void Awake()
    {
        cardManager = GameObject.Find("Manager").GetComponent<CardManager>();
    }

    


    public void Rotate()
    {
        // Rotate the card 90 degrees clockwise

        // Update the door directions
        DoorDirection newDoorDirections = DoorDirection.None;
        if (doorDirections.HasFlag(DoorDirection.North))
            newDoorDirections |= DoorDirection.East;
        if (doorDirections.HasFlag(DoorDirection.East))
            newDoorDirections |= DoorDirection.South;
        if (doorDirections.HasFlag(DoorDirection.South))
            newDoorDirections |= DoorDirection.West;
        if (doorDirections.HasFlag(DoorDirection.West))
            newDoorDirections |= DoorDirection.North;

        doorDirections = newDoorDirections;
        UpdateDoors();
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

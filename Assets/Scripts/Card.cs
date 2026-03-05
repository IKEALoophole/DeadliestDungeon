using UnityEngine;

public class Card : MonoBehaviour
{
    public bool placed = false;

    public bool tryPlaceCard()
    {
        var transformPos = transform.position;
        Physics2D.OverlapPoint(transformPos);
        return true;
    }
}

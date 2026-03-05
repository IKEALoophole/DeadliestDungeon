using Unity.VisualScripting;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector3 offSet = Vector3.zero;
    [SerializeField]
    private bool active = true;
    private Card cardScript;

    void Start()
    {
        var collider = gameObject.GetComponent<Collider2D>();
        cardScript = gameObject.GetComponent<Card>();
        if (collider == null)
        {
            Debug.LogError("Draggable object " + gameObject.name + " does not have a Collider component.");
        }
    }

    void Update()
    {
        if (cardScript.placed)
        {
            active = false;
        }
    }

    void OnMouseDown()
    {
        if (!active)
            return;
        //Debug.Log("Mouse down on " + gameObject.name);
        var mouseScreenSpace = Input.mousePosition;
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenSpace);
        offSet = gameObject.transform.position - mouseWorldPos;
    }

    void OnMouseDrag()
    {
        if (!active)
            return;
        var mouseScreenSpace = Input.mousePosition;
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenSpace);
        gameObject.transform.position = mouseWorldPos + offSet;       
    }

    void OnMouseUp()
    {
        if (!active)
            return;
        Debug.Log("Mouse up on " + gameObject.name);
        cardScript.cardManager.tryPlaceCard(cardScript);
    }
}

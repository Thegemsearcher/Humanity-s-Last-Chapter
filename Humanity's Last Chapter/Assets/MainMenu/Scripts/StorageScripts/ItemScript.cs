using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    bool held = false;
    Vector3 slotPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !held)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<Collider2D>().OverlapPoint(mousePosition))
            {
                if (!held)
                {
                    held = true;
                    MouseData.HoldItem(gameObject);
                }
            }
        }
        else if (Input.GetMouseButton(0) && held)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.GetComponent<Transform>().position = mousePosition;
        }
        else if (held)
        {
            held = false;
            gameObject.GetComponent<Transform>().position = slotPosition;
            MouseData.RemoveItem();
        }
    }

    public Vector3 SlotPositon()
    {
        return slotPosition;
    }

    public void SetSlot(Vector3 SlotPosition)
    {
        slotPosition = SlotPosition;
        gameObject.GetComponent<Transform>().position = slotPosition;
    }

    public void SetColor(Color newColor)
    {
        gameObject.GetComponent<SpriteRenderer>().color = newColor;
    }

    public GameObject CreateItem()
    {
        return gameObject;
    }
}

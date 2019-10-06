using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    bool held = false;
    bool active = false;
    Vector3 slotPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (Input.GetMouseButtonDown(0) && !held) //If picking up this
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
            else if (Input.GetMouseButton(0) && held) //If holding onto this
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                gameObject.GetComponent<Transform>().position = mousePosition;
            }
            else if (held) //If this was let go
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                List<GameObject> items = new List<GameObject>(GameObject.FindGameObjectsWithTag("Item"));
                foreach (GameObject item in items)
                {
                    if (item != gameObject && item.GetComponent<Collider2D>().OverlapPoint(mousePosition))
                    {
                        SwitchPositions(gameObject, item);
                        break;
                    }
                }

                held = false;
                gameObject.GetComponent<Transform>().position = slotPosition;
                MouseData.RemoveItem();
            }
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
        active = true;
    }

    public void SetInactive()
    {
        active = false;
    }

    public GameObject CreateItem()
    {
        return gameObject;
    }

    public void SwitchPositions(GameObject droppedItem, GameObject onItem)
    {
        Vector2 droppedItemPosition = droppedItem.GetComponent<ItemScript>().SlotPositon();
        Vector3 onItemPosition = onItem.GetComponent<ItemScript>().SlotPositon();
        droppedItem.GetComponent<ItemScript>().SetSlot(onItemPosition);
        onItem.GetComponent<ItemScript>().SetSlot(droppedItemPosition);
    }
}
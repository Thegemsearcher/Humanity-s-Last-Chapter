using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoveItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private string id;
    private int slotNr, newSlotNr;

    private bool inside, held;
    private Vector2 mousePos;
    private GameObject moveParent;
    private Transform oldParent;
    private ItemInfo itemInfo;
    private GameObject[] ItemSlots, WeaponSlots, ClothSlots, InventorySlots;

    void Start()
    {
        //moveParent = GameObject.FindGameObjectWithTag("LoadManager").transform;
        oldParent = transform.parent;
        InventorySlots = GameObject.FindGameObjectsWithTag("InventorySlot");
        ItemSlots = GameObject.FindGameObjectsWithTag("ItemSlot");
        WeaponSlots = GameObject.FindGameObjectsWithTag("WeaponSlot");
        ClothSlots = GameObject.FindGameObjectsWithTag("ClothSlot");

        moveParent = GameObject.FindGameObjectWithTag("StorageMoveParent");
        slotNr = GetComponentInParent<ItemSlotScript>().slotNr;
        itemInfo = GetComponent<ItemInfo>();
        id = GetComponent<ItemInfo>().id;
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (held)
        {
            gameObject.transform.position = mousePos;
            if (Input.GetMouseButtonDown(0))
            {
                Place();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && GetComponent<Collider2D>().OverlapPoint(mousePos)) //inside) {
            {
                held = true;
                GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        inside = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inside = false;
    }

    public void Place()
    {
        held = false;
        //Check Inventory Slots
        foreach (GameObject itemSlot in GameObject.FindGameObjectsWithTag("ItemSlot"))
        {
            if (Move(itemSlot))
            {
                break;
            }
        }
        //Check Weapon Slots
        if (id[0] == 'w')
        {
            foreach (GameObject weaponSlot in GameObject.FindGameObjectsWithTag("WeaponSlot"))
            {
                if (Move(weaponSlot))
                {
                    break;
                }
            }
        }
        transform.position = transform.parent.position;
    }


    private bool Move(GameObject itemSlot)
    {
        //If we are inside the slot with the mouse...
        if (itemSlot.GetComponent<ItemSlotScript>().inside)
        {
            if (!itemSlot.GetComponent<ItemSlotScript>().isActive)
            {
                //Set old slot to inactive
                oldParent.GetComponent<ItemSlotScript>().isActive = false;
                //Make new slot active
                itemSlot.GetComponent<ItemSlotScript>().isActive = true;
                //Set the slot this this item's info
                itemSlot.GetComponent<ItemSlotScript>().GetItem(itemInfo.strName, itemInfo.strDesc, oldParent.GetComponent<ItemSlotScript>().Parent);
                //Set this item's parent to the new slot
                gameObject.transform.SetParent(itemSlot.transform, false);
                //Set the new slot to this item's "old" parent, I guess...
                oldParent = transform.parent;
                //Put the item on the new slot
                transform.position = transform.parent.position;
            }
            else
            {
                //Set old slot to inactive
                oldParent.GetComponent<ItemSlotScript>().isActive = false;
                //Make new slot active
                itemSlot.GetComponent<ItemSlotScript>().isActive = true;
                //Set this item's parent to the new slot
                gameObject.transform.SetParent(itemSlot.transform, false);
                //Set the new slot to this item's "old" parent, I guess...
                oldParent = transform.parent;
                //Put the item on the new slot
                transform.position = transform.parent.position;
            }
            GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            return true;
        }
        return false;
    }
}

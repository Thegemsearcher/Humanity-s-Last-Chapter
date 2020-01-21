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
            //gameObject.transform.position = mousePos;
            if (Input.GetMouseButtonDown(0))
            {
                if (oldParent.GetComponent<ItemSlotScript>().inside)
                {
                    oldParent.GetComponent<ItemSlotScript>().SetDefaultColor();
                    moveParent.GetComponent<ItemGrabberScript>().Release();
                    held = false;
                }
                else
                {
                    Place();
                }
            }
        }
        else
        {
            if (!moveParent.GetComponent<ItemGrabberScript>().holding)
            {
                if (Input.GetMouseButtonDown(0) && GetComponent<Collider2D>().OverlapPoint(mousePos)) //inside) {
                {
                    oldParent.GetComponent<Image>().color = Color.green;
                    held = true;
                    moveParent.GetComponent<ItemGrabberScript>().NewItem(this.GetComponent<Image>().sprite);
                    GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
                }
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
        //Stop holding this item
        held = false;

        //Check Inventory Slots
        foreach (GameObject itemSlot in GameObject.FindGameObjectsWithTag("ItemSlot"))
        {
            if (Move(itemSlot))
            {
                return;
            }
        }
        //Check Weapon Slots
        if (id[0] == 'w')
        {
            foreach (GameObject weaponSlot in GameObject.FindGameObjectsWithTag("WeaponSlot"))
            {
                if (Move(weaponSlot))
                {
                    return;
                }
            }
        }
        //Check Clothes Slots
        else if (id[0] == 'c' && id[1] == 'l')
        { //ClothSlot
            ClothItemObject[] clothTemp = Assets.assets.clothTemp;
            foreach (ClothItemObject cloth in clothTemp)
            {
                if (id == cloth.name)
                {
                    if (cloth.clothType == ClothScript.ClothType.Cloth)
                    {
                        foreach (GameObject ClothSlot in GameObject.FindGameObjectsWithTag("ClothSlot"))
                        {
                            if (Move(ClothSlot))
                            {
                                return;
                            }
                        }
                    }
                    else
                    {
                        foreach (GameObject hatSlot in GameObject.FindGameObjectsWithTag("HatSlot"))
                        {
                            if (Move(hatSlot))
                            {
                                return;
                            }
                        }
                    }
                    break;
                }
            }

        }
        else if (id[0] == 'h')
        {
            foreach (GameObject healSlot in GameObject.FindGameObjectsWithTag("HealSlot"))
            {
                if (Move(healSlot))
                {
                    return;
                }
            }
        }
        else if (id[0] == 'c' && id[1] == 'i')
        { //CombatItem
            foreach (GameObject CombatItem in GameObject.FindGameObjectsWithTag("CombatSlot"))
            {
                if (Move(CombatItem))
                {
                    return;
                }
            }
        }


        //if (transform.parent.tag == "ItemSlot")
        //{
        //    if (transform.parent.childCount > 1)
        //    {
        //        //This should switch them.
        //        held = true;
        //        moveParent.GetComponent<ItemGrabberScript>().NewItem(this.GetComponent<Image>().sprite);
        //        return;
        //    }

        //}
        //else if (transform.parent.childCount > 2)
        //{ // cred till LINNEA 
        //  //Om det finns fler än 2 barn betyder det att det finns 2 potensiella items på samma ruta + texten
        //    held = true;
        //    moveParent.GetComponent<ItemGrabberScript>().NewItem(this.GetComponent<Image>().sprite);
        //    return;
        //}
        Debug.Log("Well, it got here, so that's interesting...");
        moveParent.GetComponent<ItemGrabberScript>().Release();
        oldParent.GetComponent<ItemSlotScript>().SetDefaultColor();
        //transform.position = transform.parent.position;
        //OldSlotCheck();
    }

    
    //private void OldSlotCheck() //This isn't used
    //{ //Kollar ifall det är möjligt att skicka tillbaka där den är
    //    if (oldParent.GetComponent<ItemSlotScript>().isActive)
    //    {
    //        foreach (GameObject itemSlot in GameObject.FindGameObjectsWithTag("ItemSlot"))
    //        {
    //            if (!itemSlot.GetComponent<ItemSlotScript>().isActive)
    //            {
    //                //Make new slot active
    //                itemSlot.GetComponent<ItemSlotScript>().isActive = true;
    //                //Set the slot this this item's info
    //                itemSlot.GetComponent<ItemSlotScript>().GetItem(itemInfo.strName, itemInfo.strDesc, oldParent.GetComponent<ItemSlotScript>().Parent);
    //                //Set this item's parent to the new slot
    //                gameObject.transform.SetParent(itemSlot.transform, false);
    //                //Set the new slot to this item's "old" parent, I guess...
    //                oldParent = transform.parent;
    //                //Put the item on the new slot
    //                transform.position = transform.parent.position;
    //                break;
    //            }
    //        }
    //    }
    //    else
    //    {
    //        if (transform.parent.tag == "ItemSlot")
    //        {
    //            if (transform.parent.childCount > 1)
    //            {
    //                held = true;
    //                moveParent.GetComponent<ItemGrabberScript>().NewItem(this.GetComponent<Image>().sprite);
    //                return;
    //            }

    //        }
    //        else if (transform.parent.childCount > 2)
    //        { // cred till LINNEA 
    //          //Om det finns fler än 2 barn betyder det att det finns 2 potensiella items på samma ruta + texten
    //            held = true;
    //            moveParent.GetComponent<ItemGrabberScript>().NewItem(this.GetComponent<Image>().sprite);
    //            return;
    //        }
    //        transform.position = transform.parent.position;
    //    }
    //}


    private bool Move(GameObject itemSlot)
    {
        bool isMoveable = false;
        if (itemSlot.GetComponent<ItemSlotScript>().inside)
        { //Ifall musen är innanför en ruta
            if (itemSlot.tag == "ItemSlot")
            {
                if (itemSlot.transform.childCount <= 0)
                { //Har inga barn i sig
                    isMoveable = true;
                }
            }
            else if (itemSlot.transform.childCount <= 1)
            { //Har endast text i sig
                isMoveable = true;
            }


            if (isMoveable)
            {
                moveParent.GetComponent<ItemGrabberScript>().Release();
                oldParent.GetComponent<ItemSlotScript>().SetDefaultColor();
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
                held = true;
            }
            GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
            return true;
        }
        return false;
    }
}

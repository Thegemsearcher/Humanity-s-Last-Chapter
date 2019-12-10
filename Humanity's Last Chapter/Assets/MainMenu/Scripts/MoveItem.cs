using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    private string id;
    private int slotNr, newSlotNr;

    private bool inside, held;
    private Vector2 mousePos;
    private GameObject moveParent;
    private Transform oldParent;
    private ItemInfo itemInfo;
    private GameObject[] ItemSlots, WeaponSlots, ClothSlots, InventorySlots;

    void Start() {
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

    private void Update() {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (held) {
            gameObject.transform.position = mousePos;
            if (Input.GetMouseButtonDown(0)) {
                Place();
            }
        } else {
            if (Input.GetMouseButtonDown(0) && GetComponent<Collider2D>().OverlapPoint(mousePos)) {//inside) {
                held = true;
                //transform.SetParent(moveParent.transform, true);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("true!");
        inside = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        inside = false;
    }

    public void Place() {
        held = false;
        foreach (GameObject itemSlot in ItemSlots) {

            if (itemSlot.GetComponent<ItemSlotScript>().inside) {
                if (!itemSlot.GetComponent<ItemSlotScript>().isActive) {
                    itemSlot.GetComponent<ItemSlotScript>().isActive = true;
                    itemSlot.GetComponent<ItemSlotScript>().GetItem(itemInfo.strName, itemInfo.strDesc, oldParent.GetComponent<ItemSlotScript>().Parent);
                    slotNr = newSlotNr;
                    gameObject.transform.SetParent(itemSlot.transform, false);
                    transform.position = transform.parent.position;
                    oldParent = transform.parent;
                } else {
                    Debug.Log("Slot[" + newSlotNr + "] is taken");
                    gameObject.transform.SetParent(oldParent, false);
                    transform.position = transform.parent.position;
                }
                break;
            }
        }
        if (id[0] == 'w') {
            foreach (GameObject weaponSlot in WeaponSlots) {
                if (weaponSlot.GetComponent<ItemSlotScript>().inside) {
                    if (!weaponSlot.GetComponent<ItemSlotScript>().isActive) {
                        weaponSlot.GetComponent<ItemSlotScript>().isActive = true;
                        weaponSlot.GetComponent<ItemSlotScript>().GetItem(itemInfo.strName, itemInfo.strDesc, oldParent.GetComponent<ItemSlotScript>().Parent);
                        slotNr = newSlotNr;
                        gameObject.transform.SetParent(weaponSlot.transform, false);
                        transform.position = transform.parent.position;
                        oldParent = transform.parent;
                    } else {
                        Debug.Log("Slot[" + newSlotNr + "] is taken");
                        gameObject.transform.SetParent(oldParent, false);
                        transform.position = transform.parent.position;
                    }
                    break;
                }
            }
        }
        
        //foreach (GameObject clothSlot in ClothSlots) {
        //    if (clothSlot.GetComponent<ItemSlotScript>().inside) {
        //        if (WorldScript.world.storageArr[slotNr] == "") {
        //            Move(clothSlot);
        //        }
        //        break;
        //    }
        //}
        foreach (GameObject inventorySlot in InventorySlots) {
            if (inventorySlot.GetComponent<ItemSlotScript>().inside /*&& inventorySlot.GetComponent<ItemSlotScript>().slotNr != slotNr*/) {
                newSlotNr = inventorySlot.GetComponent<ItemSlotScript>().slotNr;

                Debug.Log("Slot[" + newSlotNr + ": " + WorldScript.world.storageArr[newSlotNr]);
                if (WorldScript.world.storageArr[newSlotNr] == "" || WorldScript.world.storageArr[newSlotNr] == null) {
                    Move(inventorySlot);
                } else {
                    Debug.Log("Slot[" + newSlotNr + "] is taken");
                    
                }
                break;
            }
        }

        gameObject.transform.SetParent(oldParent, false);
        transform.position = transform.parent.position;


        //for (int i = 0; i < ItemSlots.Length; i++) {
        //    if (ItemSlots[i].GetComponent<ItemSlotScript>().inside) {
        //        Debug.Log("Slot[" + i + "]: " + WorldScript.world.storageArr[i]);
        //        if (WorldScript.world.storageArr[i] == null || WorldScript.world.storageArr[i] == "") {
        //            WorldScript.world.MoveItem(slotNr, i, id);
        //            slotNr = i;

        //        } else {
        //            Debug.Log("Slot[" + i + "] is taken");
        //            break;
        //        }

        //    }
        //}

    }

    private void Move(GameObject slot) {
        WorldScript.world.MoveItem(slotNr, newSlotNr, id);
        slotNr = newSlotNr;
        //if(oldParent.transform.tag == "WeaponSlot") {
            
        //}
        oldParent.GetComponent<ItemSlotScript>().isActive = false;
        gameObject.transform.SetParent(slot.transform, false);
        transform.position = transform.parent.position;
        oldParent = transform.parent;
    }
}
